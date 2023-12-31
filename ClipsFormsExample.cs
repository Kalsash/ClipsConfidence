﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLIPSNET;
using System.Speech.Synthesis;

namespace ClipsFormsExample
{
    public partial class ClipsFormsExample : Form
    {
        private CLIPSNET.Environment clips = new CLIPSNET.Environment();

        Dictionary<int, Fact> facts;
        Dictionary<int, Rule> rules;
        private string clipsCode = "";

        String dbFolderName = "C:\\Code\\CLIPSForms\\db";

        public ClipsFormsExample()
        {
            InitializeComponent();
            facts = new Dictionary<int, Fact>();
            rules = new Dictionary<int, Rule>();
            nextButton.Text = "Старт";
            setState(false);

        }

        void setState(bool state)
        {
            saveAsButton.Enabled = state;
            fontButton.Enabled = state;
            resetButton.Enabled = state;
            nextButton.Enabled = state;
        }

        void askSomeQuestion(string message, List<string> answers)
        {
            List<KeyValuePair<int, Fact>> selectedFacts;
            AskingDialog form = new AskingDialog();
            if (message.EndsWith("features"))
            {
                form = new AskingDialog("Выберите доп функционал:", answers, false);
            }
            else if (message.EndsWith("card"))
            {
                form = new AskingDialog("Какие видеокарты вас интересуют?", answers, true);
            }
            else if (message.EndsWith("memory"))
            {
                form = new AskingDialog("Сколько оперативной памяти нужно?", answers, true);
            }
            else if (message.EndsWith("budget"))
            {
                form = new AskingDialog("Каков ваш бюджет?", answers, true);
            }
            else if (message.EndsWith("proc"))
            {
                form = new AskingDialog("Какие процеесоры вас интересуют?", answers, true);
            }
            else
            {
                throw new Exception("Ошибка с Clips");
            }
            form.ShowDialog(this);
            selectedFacts = form.SelectedFacts;
            foreach (var pair in selectedFacts)
            {
                var x =
                    $"(assert (fact (num {pair.Key})(description \"{pair.Value.factDescription}\")(certainty {Math.Round(pair.Value.certainty, 2).ToString(CultureInfo.InvariantCulture)})))";
                clips.Eval($"(assert (fact (num {pair.Key})(description \"{pair.Value.factDescription}\")(certainty {Math.Round(pair.Value.certainty, 2).ToString(CultureInfo.InvariantCulture)})))");
            }
        }
        int iterationCounter = 0;

        string getRuleCountDescription(int quantity)
        {
            if (quantity % 10 == 1 && quantity != 11)
            {
                return $"{quantity} правило";
            }
            if ((quantity % 10 == 2 && quantity != 12) || (quantity % 10 == 3 && quantity != 13) || (quantity % 10 == 4 && quantity != 14))
            {
                return $"{quantity} правила";
            }
            return $"{quantity} правил";
        }

        private List<KeyValuePair<string, double>> finalChoice;
        private bool HandleResponse()
        {
            //  Вытаскиаваем факт из ЭС
            String evalStr = "(find-fact ((?f ioproxy)) TRUE)";
            FactAddressValue fv = (FactAddressValue)((MultifieldValue)clips.Eval(evalStr))[0];

            MultifieldValue damf = (MultifieldValue)fv["messages"];
            MultifieldValue vamf = (MultifieldValue)fv["answers"];
            if (damf.Count == 0)
            {
                return false;
            }
            //outputBox.Text += "Новая итерация : " + System.Environment.NewLine;
            for (int i = 0; i < damf.Count; i++)
            {
                LexemeValue da = (LexemeValue)damf[i];
                byte[] bytes = Encoding.Default.GetBytes(da.Value);
                string message = Encoding.UTF8.GetString(bytes);
                if (message.StartsWith("#ask"))
                {
                    iterationCounter = 0;
                    var phrases = new List<string>();
                    if (vamf.Count > 0)
                    {
                        outputBox.AppendText("----------------------------------------------------" + System.Environment.NewLine, Color.Brown);
                        for (int j = 0; j < vamf.Count; j++)
                        {
                            //  Варианты !!!!!
                            LexemeValue va = (LexemeValue)vamf[j];
                            byte[] bytess = Encoding.Default.GetBytes(va.Value);
                            string messagee = Encoding.UTF8.GetString(bytess);
                            phrases.Add(messagee);
                            outputBox.AppendText("Добавлен вариант для распознавания " + messagee + System.Environment.NewLine, Color.Brown);
                        }
                        outputBox.AppendText("----------------------------------------------------" + System.Environment.NewLine, Color.Brown);
                    }

                    askSomeQuestion(message, phrases);
                    outputBox.AppendText(message + System.Environment.NewLine, Color.DarkBlue);
                }
                else if (message.StartsWith("#"))
                {
                    outputBox.AppendText(message + System.Environment.NewLine, Color.Green);
                    var parts = message.Split('|');
                    finalChoice.Add(new KeyValuePair<string, double>(parts[1], double.Parse(parts[3], CultureInfo.InvariantCulture)));
                }
                else
                {
                    outputBox.AppendText(message + System.Environment.NewLine, Color.Black);
                }

                outputBox.SelectionStart = outputBox.Text.Length;
                outputBox.ScrollToCaret();
            }


            //if (vamf.Count == 0)
            clips.Eval("(assert (clearmessage))");
            iterationCounter++;
            return true;
        }
        bool isFirstTime = true;
        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                nextButton.Text = "Дальше";
                isFirstTime = false;
            }
            clips.Run();
            while (HandleResponse())
            {
                clips.Run();
            }
            outputBox.AppendText("Вывод завершён!\n", Color.DarkGreen);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text = "Рестарт" + System.Environment.NewLine;
            finalChoice = new List<KeyValuePair<string, double>>();
            iterationCounter = 0;
            //  Здесь сохранение в файл, и потом инициализация через него
            clips.Clear();

            //  Так тоже можно - без промежуточного вывода в файл
            clips.LoadFromString(clipsCode);

            clips.Reset();
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                dbFolderName = folderBrowserDialog1.SelectedPath;
                loadDB();
                codeBox.Text = clipsCode = generateCLIPScode();
                setState(true);
                //outputBox.Text = "Рестарт" + System.Environment.NewLine;
                finalChoice = new List<KeyValuePair<string, double>>();
                iterationCounter = 0;
                //  Здесь сохранение в файл, и потом инициализация через него
                clips.Clear();

                //  Так тоже можно - без промежуточного вывода в файл
                clips.LoadFromString(clipsCode);

                clips.Reset();
            }
        }

        private void fontSelect_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                codeBox.Font = fontDialog1.Font;
                outputBox.Font = fontDialog1.Font;
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            clipsSaveFileDialog.FileName = "bar_data.clp";
            if (clipsSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(clipsSaveFileDialog.FileName, codeBox.Text);
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void outputBox_TextChanged(object sender, EventArgs e)
        {

        }
    }


    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}