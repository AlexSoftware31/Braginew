const TRASLATION_GUIDE_TRAVELTICKET = {
    ES: {
        welcome: "Bienvenido",
        hello: `
          El formulario está dividido en pasos que debe ir completando,
            este es el primer paso del formulario donde deberá llenar los siguientes campos de la información
            general. Una vez completada la información deberá pulsar siguiente
            y el número de ese paso se marcará como completado y pasará al siguiente.
            </br><i><b>Cada uno de los campos son requeridos</b></i>`,
        next: "CONTINUAR",
        back: "ATRAS",
        done: "TERMINAR",
        close: "CERRAR",
        guide2Title: "INFORMACIÓN MIGRATORIA",
        guide2Body: `Como observa el paso anterior se marcó como completado. Este paso es el de información migratoria debe llenar cada uno de los campos mostrados en pantalla que corresponden al solicitante. En caso de haber indicado que viaja con más personas debe llenar los datos de los demás pasajeros que se irán mostrando luego de haber completado los datos del pasajero anterior`,
        isCommonTitle: "Asignar a la misma dirección",
        isCommonBody: `Este campo por defecto esta seleccionado indicando que la dirección del siguiente pasajero es común
                    pero si dicho pasajero irá a una dirección o hotel diferente puede cambiarlo y automáticamente se
                    desplegarán los campos para que cambie la dirección o hotel de dicho pasajero
`,
        guide3Title: `INFORMACIÓN ADUANAL`,
        guide3Body: `En este paso, si es de entrada su solicitud debe llenar algunas informaciones requeridas por aduana
                     por cada uno de los acompañantes en caso de ser mayores de edad en caso contrario solo saldrá un mensaje
                     indicando que no necesita llenar el formulario de aduana por ser menor de edad.
                     <br><br>
                     Si su solicitud es de salida solo se pedirá que llene los datos si indica que lleva un monto superior a 
                     los US$10,000.00`,
        guide4Body: `En este campo si indica que trae consigo más de US$10,000.00, se desplegarán más campos que debe completar
                    `,
        guide5Body: `En este campo si indica que no es el dueño de dichos valores entonces se desplegarán más campos que debe completar referentes a la persona que es dueña de lo que trae consigo`,
        guide6Body: `En este campo si indica que trae mercancías sujetas a pagos de impuestos entonces se desplegarán más campos
                     que debe completar. 
                     <br><br>
                     Mas adelante aparece un texto que dice <b>DETALLE DE MERCANCÍAS SUJETAS AL PAGO DE IMPUESTOS</b> al lado de este
                     campo hay un pequeño botón con el símbolo <b>(+)</b> el cual si indico que lleva consigo mercancía sujeta
                     a impuestos debe pulsar obligatoriamente para que se desplieguen algunos campos donde debe detallar
                     las mercancías. <i><b>Pulse dicho botón las veces que sean necesarias para detallar una nueva mercancía</b></i>`,
        guide7Title: 'SALUD PÚBLICA',
        guide7Body: `En este paso se puede observar un campo contiene que el texto <b>PAÍSES DE TRÁNSITO ANTES DE LLEGAR A REPÚBLICA DOMINICANA</b> contiene
                       botón con el símbolo <b>(+)</b> cuando dicho botón se pulsa se abre un modal con un listado de países,
                     de los cuales debe seleccionar por los cuales ha pasado antes de llegar a república dominicana, si no ha transitado
                     por ninguno no debe pulsar el botón.
                     `,
        guide8Body: `Este campo al igual que el anterior contiene un botón que despliega un modal donde debe seleccionar
                     los países que corresponda en caso contrario no pulsarlo.
`,
        guide9Body: `En este apartado debe seleccionar algunos de estos checkbox de los cuales crea correspondiente a su
                    caso. <br><br> <b><i>En caso de elegir un síntoma entonces se desplegará un nuevo campo para indicar la fecha de inicio
                     </i><b>`,
        guide10Body: `Luego de completar todos los campos y pulsado el botón de enviar se lanzará una ventana emergente donde
                        debe aceptar los términos y condiciones. Luego, automáticamente será enviado a otra pantalla
                      donde podrá ver un código que el cual debe descargar y guardar.`
    },
    EN: {
        welcome: "Welcome",
        hello: `
             The form is divided into steps that you must complete,
             this is the first step of the form where you must fill in the following fields of information
             general. Once the information is completed, you must press next
             and the number of that step will be marked as completed and will go to the next.
             </br> <i> <b> Each of the fields are required </b> </i> `,
        next: "CONTINUE",
        back: "BACK",
        done: "FINISH",
        close: "CLOSE",
        guide2Title: "MIGRATORY INFORMATION",
        guide2Body: `As you can see the previous step was marked as completed. This step is that of immigration information
           You must fill each of the fields shown on the screen that correspond to the applicant. In case of
           Having indicated that you are traveling with more people you must fill in the details of the other passengers that will be shown
           after completing the details of the previous passenger`,
        isCommonTitle: "Assign to the same address",
        isCommonBody: `This field by default is selected indicating that the address of the next passenger is common
                    but if said passenger will go to a different address or hotel, they can change it and automatically
                    They will display the fields so that the address or hotel of said passenger changes`,
        guide3Title: `CUSTOMS INFORMATION`,
        guide3Body: `In this step, if your request is input, you must fill in some information required by customs
                     for each of the companions if they are of legal age, otherwise only one message will appear
                     indicating that you do not need to fill out the customs form because you are a minor.
                     < br > <br>
                     If your request is outgoing, you will only be asked to fill in the data if you indicate that it has an amount greater than
            the US $ 10,000.00`,
        guide4Body: `In this field if you indicate that you are bringing more than US $ 10,000.00, more fields will be displayed
                     you must complete`,
        guide5Body: `In this field if you indicate that you are not the owner of these values ​​then more fields will be displayed
                     that you must complete referring to the person who owns what he brings with him`,
        guide6Body: `In this field if you indicate that you bring merchandise subject to tax payments then more fields will be displayed
                     you must complete.
                     <br> <br>
                     Later a text appears that says <b> DETAILS OF GOODS SUBJECT TO TAX PAYMENT </b> next to it
                     field there is a small button with the symbol <b> (+) </b> which if I indicate that it carries subject merchandise
                     to taxes, you must press to display some fields where you must detail
                     the goods. <i> <b> Press this button as many times as necessary to detail a new merchandise </b> </i> `,
        guide7Title: 'PUBLIC HEALTH',
        guide7Body: `In this step you can see a field that contains the text<b> TRANSIT COUNTRIES BEFORE YOU ARRIVE IN THE DOMINICAN REPUBLIC </b> contains
                       button with the symbol<b>(+) </b> when said button is pressed, a modal will be opened with a list of countries,
                         of which you must select which you have passed through before reaching the Dominican Republic, if you have not traveled
                      you should not press the button for any of them.`,

        guide8Body: `This field like the previous one contains a button that displays a modal where you must select
                     the countries that correspond otherwise do not press it.`,
        guide9Body: `In this section you must select some of these checkboxes of which you think corresponds to your
                    case. <br> <br> <b> <i> In case of choosing a symptom, a new field will be displayed to indicate the start date
                     </i> <b> `,
        guide10Body: `After completing all the fields and pressing the send button, a pop-up window will be launched where
                        You must accept the terms and conditions. Then it will automatically be sent to another screen
                      where you can see a qr code which you must download and save.`
    },
    PT: {
        welcome: "vindo bem vindo",
        hello: `
            O formulário é dividido em etapas que você deve preencher,
            Este é o primeiro passo do formulário onde você deve preencher os seguintes campos de informação
            geral. Assim que as informações forem preenchidas, você deve pressionar próximo
            e o número dessa etapa será marcado como concluído e passará para a próxima.
            </br> <i> <b> Cada um dos campos é obrigatório </b> </i> `,
        next: "NEXT",
        back: "VOLTAR",
        done: "FINISH",
        close: "FECHAR",
        guide2Title: "MIGRATORY INFORMATION",
        guide2Body: `Como você pode ver, a etapa anterior foi marcada como concluída. Esta etapa é a informação de imigração
           Você deve preencher cada um dos campos mostrados na tela que correspondem ao candidato. No caso de
           Tendo indicado que está a viajar com mais pessoas, deverá preencher os dados dos restantes passageiros que lhe serão apresentados
           depois de ter preenchido os dados do passageiro anterior`,
        isCommonTitle: "Atribuir ao mesmo endereço",
        isCommonBody: `Este campo por padrão é selecionado indicando que o endereço do próximo passageiro é comum
mas se o referido passageiro for para um endereço ou hotel diferente, ele pode alterá - lo e automaticamente
Eles irão exibir os campos para alterar o endereço ou hotel do referido passageiro `,
        guide3Title: `CUSTOMS INFORMATION`,
        guide3Body: `Nesta etapa, se o seu aplicativo for inserido, você deve preencher algumas informações exigidas pela alfândega
                     para cada um dos acompanhantes no caso de ser maior de idade, caso contrário aparecerá apenas uma mensagem
                     indicando que você não precisa preencher o formulário da alfândega por ser menor de idade.
                     <br> <br>
                     Se sua solicitação for de saída, você só precisará preencher os dados se indicar que tem um valor maior que
                     os US $ 10.000,00`,
        guide4Body: `Neste campo, se você indicar que traz mais de US $ 10.000,00, mais campos serão exibidos
                     a ser completado `,
        guide5Body: `Neste campo, se você indicar que não é o proprietário desses valores, mais campos serão exibidos
que você deve preencher referindo - se à pessoa que possui o que trazem com eles `,
        guide6Body: `Neste campo, se você indicar que traz mercadorias sujeitas a pagamentos de impostos, mais campos serão exibidos
                     que você deve completar.
                     <br> <br>
                     Mais tarde, aparece um texto que diz <b> DETALHE DE MERCADORIAS SUJEITAS A PAGAMENTO DE TAXAS </b> ao lado deste
                     campo há um pequeno botão com o símbolo <b> (+) </b> que se eu indicar que carrega a mercadoria do assunto
                     aos impostos você deve clicar para que alguns campos sejam exibidos onde você deve detalhar
                     os bens. <i> <b> Pressione este botão quantas vezes forem necessárias para detalhar uma nova mercadoria </b> </i> `,
        guide7Title: 'SAÚDE PÚBLICA',
        guide7Body: `Nesta etapa, você pode ver um campo que contém o texto <b> PAÍSES DE TRÂNSITO ANTES DE CHEGAR NA REPÚBLICA DOMINICANA </b> contém
                       botão com o símbolo <b> (+) </b> quando este botão é pressionado um modal será aberto com uma lista de países,
                     dos quais você deve selecionar por quais já passou antes de chegar à República Dominicana, se não tiver viajado
                     para nenhum não deve pressionar o botão.
                     `,
        guide8Body: `Este campo, como o anterior, contém um botão que exibe um modal onde você deve selecionar
                     os países que correspondem de outra forma não o pressionam.`,
        guide9Body: `Nesta seção, você deve selecionar algumas dessas caixas de seleção que você cria correspondentes ao seu caso. < br > <br> <b> <i> No caso de escolher um sintoma, um novo campo será exibido para indicar a data de início
                     </i> <b> `,
        guide10Body: `Depois de preencher todos os campos e pressionar o botão enviar, uma janela pop-up será aberta onde
    Você deve aceitar os Termos e Condições. Em seguida, ele será enviado automaticamente para outra tela
    onde você pode ver um código qr que você deve baixar e salvar.`
    },
    IT: {
        welcome: " benvenuto",
        hello: `
            Il modulo è suddiviso in passaggi che devi completare,
            Questo è il primo passaggio del modulo in cui è necessario compilare i seguenti campi di informazioni
            generale. Una volta completate le informazioni, è necessario premere Avanti
            e il numero di quel passaggio sarà contrassegnato come completato e passerà a quello successivo.
            </br> <i> <b> Ciascun campo è obbligatorio </b> </i>   `,
        next: "NEXT",
        back: "indietro",
        done: "FINISH",
        close: "CLOSE",
        guide2Title: "INFORMAZIONI MIGRATORIE",
        guide2Body: `Come puoi vedere, il passaggio precedente è stato contrassegnato come completato.Questo passaggio è l'informazione sull'immigrazione
           È necessario compilare ciascuno dei campi visualizzati sullo schermo che corrispondono al richiedente.In caso di
           Avendo indicato che viaggi con più persone, devi inserire i dati degli altri passeggeri che ti verranno mostrati
           dopo aver completato i dati del passeggero precedente`,
        isCommonTitle: "Assegna allo stesso indirizzo",
        isCommonBody: `Questo campo per impostazione predefinita è selezionato per indicare che l'indirizzo del prossimo passeggero è comune
                    ma se detto passeggero andrà a un indirizzo o hotel diverso, può cambiarlo automaticamente
                    Visualizzeranno i campi per modificare l'indirizzo o l'hotel di detto passeggero`,
        guide3Title: `INFORMAZIONI DOGANALI`,
        guide3Body: `In questo passaggio, se viene inserita la tua domanda, devi inserire alcune informazioni richieste dalla dogana
                     per ciascuno degli accompagnatori in caso di maggiore età, altrimenti verrà visualizzato un solo messaggio
                     indicando che non è necessario compilare il modulo doganale perché minorenne.
                     <br> <br>
                     Se la tua richiesta è in uscita, ti verrà chiesto di inserire i dati solo se indichi di avere un importo superiore a
                     $ 10.000,00 `,
        guide4Body: `In questo campo se indichi di portare più di US $ 10.000, 00, verranno visualizzati più campi
                     da completare`,
        guide5Body: `In questo campo se indichi di non essere il proprietario di questi valori, verranno visualizzati più campi
                     che devi completare riferendoti alla persona che possiede ciò che porta con sé `,
        guide6Body: `In questo campo se indichi che porti merce soggetta a pagamento delle tasse, verranno visualizzati più campi
                     che devi completare.
                     < br > <br>
            Successivamente viene visualizzato un testo che dice <b> DETTAGLIO MERCE SOGGETTO A PAGAMENTO TASSE </b> accanto a questo
                     campo c'è un piccolo pulsante con il simbolo <b> (+) </b> che se indico che trasporta merce in oggetto
                     per le tasse devi fare clic in modo che vengano visualizzati alcuni campi in cui devi dettagliare
                     i beni. <i> <b> Premi questo pulsante tante volte quanto necessario per dettagliare una nuova merce </b> </i> `,
        guide7Title: "SALUTE PUBBLICA",
        guide7Body: `In questo passaggio puoi vedere un campo che contiene il testo <b> TRANSIT COUNTRIES BEFORE ARRIVING IN THE DOMINICAN REPUBLIC </b> contiene
                       pulsante con il simbolo <b> (+) </b> quando questo pulsante viene premuto si aprirà una modale con un elenco di paesi,
                     di cui devi selezionare quelli che hai attraversato prima di arrivare nella Repubblica Dominicana, se non hai viaggiato
                     per nessuno non dovrebbe premere il pulsante.
                     `,
        guide8Body: `Questo campo, come il precedente, contiene un pulsante che mostra un modale da selezionare
                     i paesi che corrispondono altrimenti non lo premono.`,
        guide9Body: `In questa sezione devi selezionare alcune di queste caselle di controllo che crei corrispondenti al tuo
                    Astuccio. <br> <br> <b> <i> In caso di scelta di un sintomo, verrà visualizzato un nuovo campo per indicare la data di inizio
                     </i> <b> `,
        guide10Body: `Dopo aver completato tutti i campi e premuto il pulsante di invio, verrà lanciata una finestra pop-up dove
                Devi accettare i termini e le condizioni. Quindi verrà automaticamente inviato a un'altra schermata
                dove puoi vedere un codice qr che devi scaricare e salvare.`
    },
    RU: {
        welcome: "Приветствуем вас, давайте начнём!",
        hello: `Эта анкета разделена на части (шаги), которые вам нужно
                заполнить. Это первый шаг, здесь нужно указать общие сведения о
                пассажире. После заполнения всех полей, нажмите «Далее», и этот
                шаг будет отмечен как завершённый, а вы перейдете к
                следующему. <i> <b> Все поля обязательны для заполнения </b> </i>`,
        next: "ДАЛЕЕ",
        back: "НАЗАД",
        done: "ФИНИШ",
        close: "ЗАКРЫТЬ",
        guide2Title: "СВЕДЕНИЯ, ПОДАВАЕМЫЕ В МИГРАЦИОННОЕ УПРАВЛЕНИЕ",
        guide2Body: `Поздравляем! Предыдущий шаг завершён. Это второй шаг,
                     здесь нужно указать сведения о передвижении и
                     миграционном статусе пассажиров. Все поля обязательны
                     для заполнения. Если вы указали, что путешествуете не
                     один (-на), вам нужно указать данные других пассажиров.
                     Система предложит вам указать сведения о каждом
                     следующем пассажире после заполнения данных на
                     каждого предыдущего.`,
        isCommonTitle: "Назначить тот же адрес",
        isCommonBody: `Это поле по умолчанию выбрано, указывая, что адрес следующего пассажира общий.
                    но если указанный пассажир отправится по другому адресу или в отель, он может изменить его и автоматически
                    Они будут отображать поля для изменения адреса или гостиницы указанного пассажира.`,
        guide3Title: `СВЕДЕНИЯ, ПОДАВАЕМЫЕ В ТАМОЖЕННОЕ УПРАВЛЕНИЕ`,
        guide3Body: `Если вы заполняете анкету для въезда в Доминиканскую Республику, то в этой части заявления вам нужно указать сведения, которые требуются для предоставления в таможенные органы. Данные вносятся на каждого из совершеннолетних пассажиров, указанных в заявлении. В случае с несовершеннолетними пассажирами на экране появится сообщение, что эту часть заявления заполнять не нужно.
                     <br> <br>
                    Если вы выезжаете из Доминиканской Республики, вам понадобится заполнить эту часть заявления только, если вы укажете, что вывозите наличные денежные средства на сумму свыше 10,000 долларов США`,
        guide4Body: `В этом поле, если вы укажете, что вы приносите более 10 000, 00 долларов США, будут отображаться другие поля.
                     будет завершено '`,
        guide5Body: `В этом поле, если вы укажете, что вы не являетесь владельцем этих значений, будет отображаться больше полей
                     что вы должны завершить ссылку на человека, которому принадлежит то, что они приносят с собой`,
        guide6Body: `В этом поле, если вы укажете, что вы привозите товары, подлежащие налоговым платежам, будет отображаться больше полей что вы должны завершить.
                     < br > <br>
        Позже появится текст с надписью <b> ДЕТАЛИ ТОВАРОВ, ПРЕДНАЗНАЧЕННЫХ ДЛЯ ОПЛАТЫ НАЛОГОВ </b> рядом с этим
                     В поле есть небольшая кнопка с символом <b> (+) </b>, которая, если я укажу, что на ней есть тематические товары
                     к налогам вы должны щелкнуть так, чтобы отобразились некоторые поля, где вы должны указать
                     товар. <i> <b> Нажмите эту кнопку столько раз, сколько необходимо, чтобы подробно описать новый товар </b> </i> `,
        guide7Title: 'СВЕДЕНИЯ, ПОДАВАЕМЫЕ В МИНИСТЕРСТВО ЗДРАВООХРАНЕНИЯ',
        guide7Body: `В этой части анкеты есть раздел <b> СТРАНЫ ТРАНЗИТА ДО
                     ПРИБЫТИЯ В ДОМИНИКАНСКУЮ РЕСПУБЛИКУ </b>. Если перед
                     тем, как въехать в Доминиканскую Республику, вы
                     посещали другие государства, нажмите на <b>"+"</b>, чтобы
                     развернуть список стран и выбрать ту, где вы были
                     `,
        guide8Body: `Это поле, как и предыдущее, содержит кнопку, отображающую модальное окно, в котором вы должны выбрать
                     страны, которые соответствуют иначе, не нажимают.`,
        guide9Body: `В этом разделе вы должны выбрать некоторые из этих флажков, которые вы создаете в соответствии с вашим
                    дело. <br> <br> <b> <i> В случае выбора симптома будет отображаться новое поле для указания даты начала
                     </i> <b> `,
        guide10Body: `После заполнения всех полей и нажатия кнопки отправки откроется всплывающее окно, в котором
            Вы должны согласиться с Правилами и Условиями. Затем он будет автоматически отправлен на другой экран.
            где вы можете увидеть qr-код, который необходимо загрузить и сохранить.`
    },
    DE: {
        Wilkommen: "wilkommen",
        hello: `
            Das Formular ist in Schritte unterteilt, die Sie ausfüllen müssen.
            Dies ist der erste Schritt des Formulars, in dem Sie die folgenden Informationsfelder ausfüllen müssen
            Allgemeines. Sobald die Informationen vollständig sind, müssen Sie auf Weiter klicken
            und die Nummer dieses Schritts wird als abgeschlossen markiert und fährt mit dem nächsten fort.
            </ br> <i> <b> Jedes der Felder ist erforderlich </ b> </ i> `,
        next: "NEXT",
        back: "zurück",
        done: "FINISH",
        close: "SCHLIESSEN",
        guide2Title: "MIGRATORY INFORMATION",
        guide2Body: `Wie Sie sehen, wurde der vorherige Schritt als abgeschlossen markiert. Dieser Schritt ist die Einwanderungsinformation
           Sie müssen jedes der auf dem Bildschirm angezeigten Felder ausfüllen, die dem Antragsteller entsprechen. Im Falle von
           Nachdem Sie angegeben haben, dass Sie mit mehr Personen reisen, müssen Sie die Daten der anderen angezeigten Passagiere eingeben
           nach Abschluss der Angaben des vorherigen Passagiers "`,
        isCommonTitle: "Der gleichen Adresse zuweisen",
        isCommonBody: `Dieses Feld ist standardmäßig ausgewählt und zeigt an, dass die Adresse des nächsten Passagiers gemeinsam ist
                    Wenn der Passagier jedoch zu einer anderen Adresse oder einem anderen Hotel fährt, kann er diese automatisch ändern
                    Sie zeigen die Felder an, um die Adresse oder das Hotel des Passagiers zu ändern. `,
        guide3Title: `CUSTOMS INFORMATION`,
        guide3Body: `In diesem Schritt müssen Sie, wenn Ihre Bewerbung eingegeben wird, einige vom Zoll geforderte Informationen eingeben
                     für jeden der Gefährten im volljährigen Alter erscheint sonst nur eine Meldung
                     Dies bedeutet, dass Sie das Zollformular nicht ausfüllen müssen, weil Sie minderjährig sind.
                     <br> <br>
                     Wenn Ihre Anfrage ausgehend ist, werden Sie nur aufgefordert, die Daten einzugeben, wenn Sie angeben, dass Sie einen Betrag größer als haben
                     die US $ 10.000.00`,
        guide4Body: `Wenn Sie in diesem Feld angeben, dass Sie mehr als 10.000 US-Dollar mitbringen, werden mehr Felder angezeigt
                     zu vervollständigen`,
        guide5Body: `Wenn Sie in diesem Feld angeben, dass Sie nicht der Eigentümer dieser Werte sind, werden weitere Felder angezeigt dass Sie sich vollständig auf die Person beziehen müssen, der das gehört, was sie mitbringt `,
        guide6Body: `Wenn Sie in diesem Feld angeben, dass Sie Waren steuerpflichtig bringen, werden weitere Felder angezeigt
                     dass Sie vervollständigen müssen.
                     <br> <br>
                     Später erscheint ein Text mit der Aufschrift <b> DETAIL DER WAREN, DIE DER ZAHLUNG DER STEUERN UNTERLIEGEN </ b>
                     Feld gibt es eine kleine Schaltfläche mit dem Symbol <b> (+) </ b>, die, wenn ich anzeige, dass es Thema Waren trägt
                     Um Steuern zu erhalten, müssen Sie klicken, damit einige Felder angezeigt werden, in denen Sie Details angeben müssen
                     die Güter. <i> <b> Drücken Sie diese Taste so oft wie nötig, um eine neue Ware zu beschreiben. </ b> </ i> `,
        guide7Title: 'ÖFFENTLICHE GESUNDHEIT',
        guide7Body: `In diesem Schritt sehen Sie, dass ein Feld enthält, das den Text <b> TRANSIT COUNTRIES BEVOR DIE ANKUNFT IN DER DOMINIKANISCHEN REPUBLIK </ b> enthält
                       Schaltfläche mit dem Symbol <b> (+) </ b> Wenn diese Schaltfläche gedrückt wird, wird ein Modal mit einer Liste von Ländern geöffnet.
                     von denen müssen Sie auswählen, welche Sie durchlaufen haben, bevor Sie in der Dominikanischen Republik ankommen, wenn Sie nicht gereist sind
                     denn keiner sollte den Knopf nicht drücken.`,
        guide8Body: `Dieses Feld enthält wie das vorherige eine Schaltfläche, die ein Modal anzeigt, in dem Sie auswählen müssen
                     die Länder, die sonst korrespondieren, drücken es nicht.`,
        guide9Body: `In diesem Abschnitt müssen Sie einige dieser Kontrollkästchen aktivieren, die Sie entsprechend Ihrer erstellen Fall. < br > <br> <b> <i> Bei Auswahl eines Symptoms wird ein neues Feld mit dem Startdatum angezeigt
                     </ i> <b> `,
        guide10Body: `Nachdem Sie alle Felder ausgefüllt und auf die Schaltfläche" Senden "geklickt haben, wird ein Popup-Fenster geöffnet, in dem Du musst die Geschäftsbedingungen akzeptieren. Dann wird es automatisch an einen anderen Bildschirm gesendet Hier sehen Sie einen QR-Code, den Sie herunterladen und speichern müssen.`
    },
    FR: {
        welcome: " Bienvenue",
        hello: `
            Le formulaire est divisé en étapes que vous devez remplir,
            C'est la première étape du formulaire où vous devez remplir les champs d'information suivants
            général. Une fois l'information complétée, vous devez appuyer sur suivant
            et le numéro de cette étape sera marqué comme terminé et passera à la suivante.
            </br> <i> <b> Chacun des champs est obligatoire </b> </i> `,
        next: "Suivant",
        back: "retour",
        done: "fini",
        close: "fermer",
        guide2Title: "INFORMATIONS MIGRATOIRES",
        guide2Body: `Comme vous pouvez le voir, l'étape précédente a été marquée comme terminée. Cette étape est l'information sur l'immigration
           Vous devez remplir chacun des champs affichés à l'écran qui correspondent au demandeur. En cas de
           Après avoir indiqué que vous voyagez avec plus de personnes, vous devez renseigner les données des autres passagers qui seront affichées
           après avoir complété les coordonnées du passager précédent `,
        isCommonTitle: "Attribuer à la même adresse",
        isCommonBody: `Ce champ par défaut est sélectionné indiquant que l'adresse du prochain passager est commune
                    mais si ledit passager se rendra à une adresse ou un hôtel différent, il pourra le changer et automatiquement
                    Ils afficheront les champs pour changer l'adresse ou l'hôtel dudit passager `,
        guide3Title: `INFORMATIONS DOUANIÈRES`,
        guide3Body: `Dans cette étape, si votre demande est saisie, vous devez remplir certaines informations requises par les douanes
                     pour chacun des compagnons en cas d'âge légal, sinon un seul message apparaîtra
                     indiquant que vous n'avez pas besoin de remplir le formulaire douanier parce que vous êtes mineur.
                     <br> <br>
                     Si votre demande est sortante, il ne vous sera demandé de renseigner les données que si vous indiquez que vous avez un montant supérieur à
                     les 10 000,00 $ US `,
        guide4Body: `Dans ce champ si vous indiquez que vous apportez plus de US $ 10.000, 00, plus de champs seront affichés
                     à compléter `,
        guide5Body: `Dans ce champ si vous indiquez que vous n'êtes pas le propriétaire de ces valeurs, d'autres champs seront affichés
                     que vous devez compléter en vous référant à la personne qui possède ce qu’elle apporte avec elle`,

        guide6Body: `Dans ce champ, si vous indiquez que vous apportez de la marchandise assujettie au paiement des taxes, d'autres champs seront affichés
                     que vous devez compléter.
                     < br > <br>
            Plus tard, un texte apparaît qui dit <b> DÉTAIL DES MARCHANDISES SOUMIS AU PAIEMENT DES TAXES </b> à côté de ceci
                     champ il y a un petit bouton avec le symbole <b> (+) </b> qui si j'indique qu'il porte la marchandise en question
                     aux taxes vous devez cliquer pour que certains champs s'affichent où vous devez détailler
                     les biens. <i> <b> Appuyez sur ce bouton autant de fois que nécessaire pour détailler une nouvelle marchandise </b> </i> `,

        guide7Title: 'SANTÉ PUBLIQUE',
        guide7Body: `Dans cette étape, vous pouvez voir un champ contenant le texte <b> PAYS DE TRANSIT AVANT D'ARRIVER EN RÉPUBLIQUE DOMINICAINE </b>
                       bouton avec le symbole <b> (+) </b> lorsque ce bouton est enfoncé un modal s'ouvre avec une liste de pays,
                     dont vous devez sélectionner ceux que vous avez traversés avant d'arriver en République Dominicaine, si vous n'avez pas voyagé
                     car aucun ne doit appuyer sur le bouton.
                     `,
        guide8Body: `Ce champ, comme le précédent, contient un bouton qui affiche un modal où vous devez sélectionner
                     les pays qui correspondent autrement n'y pressent pas.`,
        guide9Body: `Dans cette section, vous devez cocher certaines de ces cases que vous créez correspondant à votre
                    Cas. <br> <br> <b> <i> En cas de choix d'un symptôme alors un nouveau champ sera affiché pour indiquer la date de début
                     </i> <b> `,
        guide10Body: `Après avoir rempli tous les champs et appuyé sur le bouton Soumettre, une fenêtre pop-up sera lancée où
                Vous devez accepter les Termes et Conditions. Ensuite, il sera automatiquement envoyé sur un autre écran
                où vous pouvez voir un code QR que vous devez télécharger et enregistrer.`
    }
};