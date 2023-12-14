; Этот блок реализует логику обмена информацией с графической оболочкой,
; а также механизм остановки и повторного пуска машины вывода
(deftemplate ioproxy			; шаблон факта-посредника для обмена информацией с GUI
	(slot fact-id)			; теоретически тут id факта для изменения
	(multislot answers)		; возможные ответы
	(multislot messages)		; исходящие сообщения
	(slot reaction)			; возможные ответы пользователя
	(slot value)			; выбор пользователя
	(slot restore)			; забыл зачем это поле
)

; Собственно экземпляр факта ioproxy
(deffacts proxy-fact
	(ioproxy
		(fact-id 0112)		; это поле пока что не задействовано
		(value none)		; значение пустое
		(messages)		; мультислот messages изначально пуст
		(answers)		; мультислот answers тоже
	)
)

(defrule append-answer-and-proceed
	(declare (salience 99))
	?current-answer <- (appendanswer ?new-ans)
	?proxy <- (ioproxy (answers $?ans-list))
	=>
	(printout t "Answer appended : " ?new-ans " ... proceed ... " crlf)
	(modify ?proxy (answers $?ans-list ?new-ans))
	(retract ?current-answer)
)

(defrule clear-messages
	(declare (salience 90))
	?clear-msg-flg <- (clearmessage)
	?proxy <- (ioproxy)
	=>
	(modify ?proxy (messages)(answers))
	(retract ?clear-msg-flg)
	(printout t "Messages cleared ..." crlf)
)

(defrule set-output-and-halt
	(declare (salience 98))
	?current-message <- (sendmessagehalt ?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Message set : " ?new-msg " ... halting ... " crlf)
	(modify ?proxy (messages ?new-msg))
	(retract ?current-message)
	(halt)
)

(defrule append-output-and-halt
	(declare (salience 98))
	?current-message <- (appendmessagehalt $?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Messages appended : " $?new-msg " ... halting ... " crlf)
	(modify ?proxy (messages $?msg-list $?new-msg))
	(retract ?current-message)
	(halt)
)

(defrule set-output-and-proceed
	(declare (salience 98))
	?current-message <- (sendmessage ?new-msg)
	?proxy <- (ioproxy)
	=>
	(printout t "Message set : " ?new-msg " ... proceed ... " crlf)
	(modify ?proxy (messages ?new-msg))
	(retract ?current-message)
)

(defrule append-output-and-proceed
	(declare (salience 98))
	?current-message <- (appendmessage ?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(printout t "Message appended : " ?new-msg " ... proceed ... " crlf)
	(modify ?proxy (messages $?msg-list ?new-msg))
	(retract ?current-message)
)

;___________________________________________________________________________

(deftemplate fact
	(slot num)
	(slot description)
	(slot certainty)
)

(deffacts start-fact
	(fact (num 6666)(description "Старт"))
)

(defrule welcome
	(declare (salience 100))
	?premise <- (fact (num 6666)(description "Старт"))
	=>
	(retract ?premise)
	(assert (fact (num 5000)(description "Про фичи ещё не спрашивали")))
	(assert (fact (num 5001)(description "Про видеокарты ещё не спрашивали")))
	(assert (fact (num 5002)(description "Про оперативку ещё не спрашивали")))
	(assert (fact (num 5003)(description "Про процессор ещё не спрашивали")))
	(assert (fact (num 5004)(description "Про бюджет ещё не спрашивали")))
	(assert (appendmessagehalt "Вывод:"))
)

(defrule askforfeatures
	(declare (salience 21))
	?premise <- (fact (num 5000)(description "Про фичи ещё не спрашивали"))
	=>
	(retract ?premise)
	(assert (appendanswer "17-подсветка_клавиатуры-89-подсветка_клавиатуры_не_нужна"))
	(assert (appendanswer "22-есть_ОС-97-ОС_не_нужна"))
	(assert (appendanswer "30-два_доп_usb-23-доп_usb_не_нужен"))
	(assert (appendanswer "24-запасной_аккумулятор-92-запасной_аккумулятор_не_нужен"))
	(assert (appendanswer "26-гарнитура-95-гарнитура_не_нужна"))
	(assert (appendanswer "28-охлаждающая_подставка-98-охлаждающая_подставка_не_нужна"))
	(assert (appendanswer "107-чехол-108-чехол_не_нужен"))
	(assert (appendanswer "110-сумка_для_ноутбука-111-сумка_для_ноутбука_не_нужна"))
	(assert (appendmessagehalt "#ask_features"))
)


(defrule askforProcessor
	(declare (salience 20))
	?premise <- (fact (num 5003)(description ?desc))
	=>
	(retract ?premise)
	(assert (appendanswer "2-12_ядер"))
	(assert (appendanswer "3-8_ядер"))
	(assert (appendanswer "6-6_ядер"))
	(assert (appendanswer "4-4_ядра"))
	(assert (appendanswer "5-2_ядра"))
	(assert (appendanswer "1-16_ядер"))
	
	(assert (appendmessagehalt "#ask_proc"))
)

(defrule askforGraphicsСard
	(declare (salience 20))
	?premise <- (fact (num 5001)(description ?desc))
	=>
	(retract ?premise)
	(assert (appendanswer "40-3050"))
	(assert (appendanswer "41-2050"))
	(assert (appendanswer "42-1650"))
	(assert (appendanswer "43-встроенная"))
	(assert (appendanswer "39-4070"))
	(assert (appendmessagehalt "#ask_card"))
)

(defrule askforbudget
	(declare (salience 20))
	?premise <- (fact (num 5004)(description ?desc))
	=>
	(retract ?premise)
	(assert (appendanswer "9-3000$"))
	(assert (appendanswer "8-2000$"))
	(assert (appendanswer "7-1000$"))
	(assert (appendanswer "10-4000$"))
	(assert (appendmessagehalt "#ask_budget"))
)

(defrule askforMemory
	(declare (salience 20))
	?premise <- (fact (num 5002)(description ?desc))
	=>
	(retract ?premise)
	(assert (appendanswer "32-32ГБ"))
	(assert (appendanswer "66-16ГБ"))
	(assert (appendanswer "31-8ГБ"))
        (assert (appendanswer "33-4ГБ"))
	(assert (appendanswer "68-64ГБ"))
	(assert (appendmessagehalt "#ask_memory"))
)

(defrule fail
	(declare (salience 10))
	=>
	(assert (appendmessagehalt "Применимые правила закончились :/"))
)

;___________________________________________________________________________
