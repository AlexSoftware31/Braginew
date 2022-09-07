
/**axios configuration token! */

axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
axios.interceptors.response.use(function (response) {
    return response;
}, function (error) {
    if (401 === error.response.status) {
        isUnauthorized();
    } else {
        return Promise.reject(error);
    }
});


/**VUEJS**/
var vue = new Vue({
    el: '#main',
    data: {
        applicationId: applicationId,
        activeStep: activeStep,
        frontStep: activeStep,
        momentjs: moment(),
        transportationMethods: [],
        countries: [],
        reasons: [],
        hotels: [],
        provinces: [],
        municipalities: [], //m
        sectors: [], //s
        currencies: [],
        ocupations: [],
        meritalStatuses: [],
        healthQuestions: [],
        searchCountryVisit: '',
        searchCountrylastVisit: '',
        personalInformation: {
            applicationId: null,
            permanentResidenceAdress: null,
            cityOfResidence: null,
            countryResidence: null,
            ocupationId: '',
            transportationMethodId: null,
            isArrival: false,
            state: null,
            zipCode: null,
            willStayAtResort: false,
            stopOverInCountries: false,
            hotelId: null,
            companions: 0,
            selectedNat: null,
            cityId: null,
            city: null
        },
        informationMigratory: [
            {
                names: null,
                lastNames: null,
                birthDate: null,
                gender: '',
                nationality: null,
                birthPlace: null,
                passportNumber: null,
                passportNumberConfirm: null,
                documentIdNumber: null,
                maritalStatusId: null,
                ocupationId: null,
                hotelId: null,
                isPrincipal: true,
                geoCode: null,
                street: null,
                originPort: null,
                originPortNavId: null,
                originPortText: 0,
                originFlightNumber: null,
                originFlightDate: null,
                embarkationPort: null,
                embarkationPortNavId: 0,
                embarkationPortText: 0,
                embarcationFlightNumber: null,
                embarcationDate: null,
                disembarkationPort: null,
                disembarkationPortNavId: 0,
                disembarkationPortText: 0,
                disembarkationFligthNumber: null,
                flightMotiveId: null,
                transportationCompany: null,
                daysOfStaying: 1,
                specificFlightMotive: null,
                hasCommonAddress: true,
                applicationId: applicationId,
                willStayAtResort: false,
                isParticularStaying: false,
                airlineId: 0,
                confirmationNumber: null,
                email: null,
                isResident: false,
                residenceNumber: null,
                sector: {
                    province: null,
                    municipalities: null
                },
                hasCommonHotel: false
            }],
        publicHealth: [
            {
                id: null,
                names: null,
                application: {
                    genericInformation: { isArrival: false }
                },
                publicHealth: {
                    applicationId: null,
                    id: 0,
                    specificsymptoms: null,
                    publicHealthsCountries: [],
                    publicHealthStopOvers: [],
                    questionResponse: [],
                    symptomsDate: null
                }
            }
        ],
        saludInformation: {
            countryVisit: [],
            countrylastVisit: []
        },
        customsInformations: [
            {
                names: null,
                customsInformation: {
                    id: null,
                    ammount: 1,
                    application: null,
                    applicationId: applicationId,
                    currency: null,
                    currencyId: null,
                    declaredOriginValue: null,
                    exceedsMoneyLimit: false,
                    hasAnimalsOrFood: false,
                    hasMerchWithTaxValue: false,
                    isUnderAge: true,
                    isValuesOwner: false,
                    senderName: null,
                    senderLastName: null,
                    receiverName: null,
                    receiverLastName: null,
                    relationShip: null,
                    worthDestiny: null,
                    currencyMerchandiseId: null,
                    valueOfMerchandise: 1,
                    declaredMerchs: [
                        { description: null, dollarValue: 1 }
                    ]

                }
            }],
        airlines: [],
        ports: [],
        intPorts: [],
        cities: [],
        searchIntPorts: '',
        searchHotels: '',
        searchCity: '',
        isLoadingMunicipality: false,
        isLoadingSector: false
    },
    mounted() {
        this.applicationId = applicationId;
        this.initialize();
    },
    methods: Modules.methods,
    computed: Modules.computeds
});




var stepper = document.querySelector('.stepper');

var stepperInstace = new MStepper(stepper, {
    // options
    firstActive: activeStep, // this is the default,
    linearStepsNavigation: true,
    // Auto focus on first input of each step.
    autoFocusInput: false,
    // Set if a loading screen will appear while feedbacks functions are running.
    showFeedbackPreloader: true,
    // Auto generation of a form around the stepper.
    autoFormCreation: true,
    // Function to be called everytime a nextstep occurs. It receives 2 arguments, in this sequece: stepperForm, activeStepContent.
    // Enable or disable navigation by clicking on step-titles
    stepTitleNavigation: false,
    validationFunction: defaultValidationFunction, // more about this default functions below

    // Preloader used when step is waiting for feedback function. If not defined, Materializecss spinner-blue-only will be used.
    feedbackPreloader: '<div class="spinner-layer spinner-blue-only">...</div>'
});

$(document).ready(() => {

    $('.tabs').tabs({
        responsiveThreshold: Infinity,
        swipeable: false
    });

    $('.datepicker').datepicker({
        setDefaultDate: true,
        yearRange: [1910, new Date().getFullYear()],
        format: "dd/mm/yyyy"
    });

    setTimeout(() => {
        $('.datepicker-PORT').datepicker({
            setDefaultDate: true,
            format: "dd/mm/yyyy",
            minDate: new Date()
        });
    }, 1000)

    loadDateTodayPicker();

    $('.tooltipped').tooltip();

    isRequiredScale('');

    $('.datepicker').keypress(function (e) {
        e.preventDefault();
    });

    setTimeout(() => {
        loadTabs();
    }, 800);

    $('.btn-block').click(() => topContent());
    notSpecialCharacters();
    loadNotSpecialCharacters();
    setTimeout(() => {
        loadPhoneMask();
        loadDateFlightPicker();
        validateFlightNumber();

    }, 1000);

    loadSelect(1100);

    setDoneStepper(activeStep);

    $('select').change((e) => {
        e.target.classList.remove("select-invalid");
    });
    validZero();
    Swal.close();

    $('.noNumbers').on('keyup', (event) => {
        event.target.value = event.target.value.replace(/[^aA-zZ. ]/g, '').replace(/(\..*)\./g, '$1');
    });

    $('.modal').modal();

    $('.emailvalidate').change(function () {
        var email = $(this).val()
        if (email.length > 35) {
            this.classList.add('invalid');
            $(this).val('')
            return;
        }
        var rgx =
            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var result = rgx.test(email)
        if (result) this.classList.remove('invalid');
        else this.classList.add('invalid');
    });

    $('.confNumber').change(function() {
        var number = $(this).val();
        if (number.length > 9) {
            this.classList.add('invalid');
            $(this).val('')
        }
    });

    notRussian();


    $('#passport').keyup(function(e) {
        if (this.value.length > 11) {
            return false;
        }
        this.value = this.value.replace(/\s/g, '');
    });

});

