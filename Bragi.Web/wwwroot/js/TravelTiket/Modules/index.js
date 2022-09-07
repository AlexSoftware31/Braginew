
var Modules = {
    methods: {
        initialize() {
            this.personalInformationGetByApplicationId();
            this.personalInformation.applicationId = this.applicationId;
            this.getAllTransportationMethods();
            this.getAllContries();
            this.getAllReasons();
            this.getAllHotels();
            this.getAllProvinces();
            this.getAllAirlines();
            this.getCurrency();
            this.getAllOcupations();
            this.getAllMeritalStatuses();
            this.getAllCustoms().catch(() => { });
            this.getAllPublicHealths();
            this.getAllQuestions(4, 2);
            this.getAllPersonsMigratory();
        },
        getIntPorts(trasnportationId) {
            CommonsService.getIntPorts(trasnportationId).then(({ data }) => {
                this.intPorts = data;
            }).catch((error) => console.log(error))
        },
        getAllPorts(transportationId) {
            CommonsService.getAllPortsByTransportationId(Number(transportationId)).then((response) => {
                if (response.status === 200) {
                    this.ports = response.data;
                }
            }).catch((error) => {
                console.log(error)

            });
        },
        getAllAirlines() {
            CommonsService.getAllAirlines().then((response) => {
                if (response.status === 200) {
                    this.airlines = response.data;
                }
            }).catch((e) => console.log(e));
        },
        getAllTransportationMethods() {
            TransportationService.getAllTransportationMethods().then((response) => {
                this.transportationMethods = response.data;
            }).catch((e) => {
                console.log(e)
            });
        },
        getAllContries() {
            GeoLocationService.getAllContries().then((response) => {
                this.countries = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllReasons() {
            CommonsService.getAllReasons().then((response) => {
                this.reasons = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllHotels() {
            CommonsService.getAllHotels().then((response) => {
                this.hotels = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllProvinces() {
            GeoLocationService.getAllProvinces().then((response) => {
                this.provinces = response.data;
                loadSelect();
            }).catch((e) => { console.log(e) });
        },
        getMunicipalities(index) {
            var provinceSelected = this.informationMigratory[index].sector.province;
            this.isLoadingMunicipality = true;
            GeoLocationService.getMunicipalities(provinceSelected).then((response) => {
                this.municipalities = response.data;
                this.isLoadingMunicipality = false;
                loadSelect();
            }).catch((e) => { console.log(e) });
        },
        getSectors(index) {
            var provinceSelected = this.informationMigratory[index].sector.province;
            var municipalitySelected = this.informationMigratory[index].sector.municipalities;
            this.isLoadingSector = true;
            GeoLocationService.getSectors(provinceSelected, municipalitySelected).then((response) => {
                this.sectors = response.data;
                this.isLoadingSector = false;
                loadSelect();
            }).catch((e) => { console.log(e) });
        },
        getCurrency() {
            CommonsService.getCurrency().then((response) => {
                this.currencies = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllOcupations() {
            CommonsService.getAllOcupations().then((response) => {
                this.ocupations = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllMeritalStatuses() {
            CommonsService.getAllMeritalStatuses().then((response) => {
                this.meritalStatuses = response.data;
            }).catch((e) => { console.log(e) });
        },
        getAllQuestions(type, agency) {
            CommonsService.getAllQuetions(type, agency).then((response) => {
                this.healthQuestions = response.data;
            }).catch((e) => { console.log(e) });
        },
        updateStep(index) {
            notRussian();
            var model = {
                applicationId: this.applicationId,
                stepsEnum: index
            };
            CommonsService.updateStep(model).then((response) => {
                // if (response.status === 200) this.frontStep = response.data.step.stepsEnum;
                setTimeout(() => {

                    $('.tabs').tabs({
                        responsiveThreshold: Infinity,
                        swipeable: false
                    });
                }, 1000);

            }).catch(() => {
                setTimeout(() => {

                    $('.tabs').tabs({
                        responsiveThreshold: Infinity,
                        swipeable: false
                    });
                }, 1000);
            });
        },

        /**personal Information */
        personalInformationUpdate() {
            this.personalInformation.applicationId = this.applicationId;
            validateAllInputs('step-1').then(() => {
                PersonalInformationService.update(this.personalInformation).then((response) => {
                    if (response.status === 400) {
                        var { errorTitle, errorHasOcurred } = getTraslations();
                        this.showAlert(errorTitle, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
                        this.updateStep(0);
                    } else {
                        this.morePerson();
                        this.updateStep(1);
                        this.updateFrontStep(1);
                        loadSelect();
                    }
                });
            }).catch(() => { });
        },
        personalInformationGetByApplicationId() {
            PersonalInformationService.getByApplicationId(this.applicationId).then((response) => {
                if (response.status === 200) {
                    this.personalInformation = response.data;
                    this.getAllPorts(this.personalInformation.transportationMethodId);
                    this.getIntPorts(this.personalInformation.transportationMethodId);
                    const city = response.data.city;
                    if (city !== null) {
                        this.personalInformation.selectedNat = city.iso2CountryCode;
                    }
                    loadingPage();
                } else {
                    var { errorTitle, errorHasOcurred } = getTraslations();
                    this.showAlert(errorTitle, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR).then(() => location.reload());
                }
            }).catch((e) => {
                console.log(e);
            });
        },
        /**end personal information */

        /**personsmigratory devils step */
        getAllPersonsMigratory() {
            var self = this;

            MigratoryInformationService.getAllPersons(self.applicationId).then((response) => {
                if (response.status === 200) {
                    console.log(response.data)
                    response.data.map((value, key) => {
                        self.informationMigratory = response.data;
                        self.informationMigratory[key].birthDate = moment(new Date(response.data[key].birthDate), "DD/MM/YYYY").format("DD/MM/YYYY");
                        self.informationMigratory[key].originFlightDate = moment(new Date(response.data[key].originFlightDate), "DD/MM/YYYY").format("DD/MM/YYYY");
                        self.informationMigratory[key].embarcationDate = moment(new Date(response.data[key].embarcationDate), "DD/MM/YYYY").format("DD/MM/YYYY");
                        self.informationMigratory[key].nationality = self.informationMigratory[key].nationality.toLowerCase();

                        self.informationMigratory[key].embarkationPortText = sessionStorage.getItem("embarkationPortText");
                        self.informationMigratory[key].originPortText = sessionStorage.getItem("originPortText");
                        self.informationMigratory[key].disembarkationPortText = sessionStorage.getItem("disembarkationPortText");

                        self.getMunicipalities(key);
                        self.getSectors(key);
                    });
                }
                Swal.close();
            }).catch((e) => {
                Swal.close();
            });



        },
        createMigratoryInformation() {
            var index = this.informationMigratory.length - 1;
            var model = this.informationMigratory[index];

            sessionStorage.setItem("embarkationPortText", model.embarkationPortText);
            sessionStorage.setItem("originPortText", model.originPortText);
            sessionStorage.setItem("disembarkationPortText", model.disembarkationPortText);

            var airlineSelected = model.airlineId;
            return validateAllInputs(`content-tabs-${index}`).then(() => {
                return new Promise((resolved, reject) => {
                    if (model.id === undefined) {

                        const birthDate = model.birthDate;
                        const originFlihtDate = model.originFlightDate;
                        const embarcationDate = model.embarcationDate;

                        //populateDates
                        model.birthDate = moment(model.birthDate, "DD/MM/YYYY").toDate();
                        model.originFlightDate = moment(model.originFlightDate, "DD/MM/YYYY").toDate();
                        model.embarcationDate = moment(model.embarcationDate, "DD/MM/YYYY").toDate();
                        const { creating, awaitMoment } = getTraslations();
                        this.isLoading(creating, awaitMoment);

                        MigratoryInformationService.create(model).then((response) => {
                            //get Id
                            this.informationMigratory[index].id = response.data.id;

                            if (index === this.personalInformation.companions) {
                                this.updateStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                this.getAllCustoms().then(() => {
                                    this.updateFrontStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                    this.loadTabs();
                                });
                            } else this.pushingPersonMigratoryInformation(index);
                            this.getAllCustoms();
                            resolved();
                            ///fix dates
                            this.informationMigratory[index].birthDate = birthDate;
                            this.informationMigratory[index].originFlightDate = originFlihtDate;
                            this.informationMigratory[index].embarcationDate = embarcationDate;
                            model.airlineId = airlineSelected;
                            Swal.close();
                        }).catch(() => {
                            this.updateFrontStep(ENUMS.FormStep.MIGRATORY_INFORMATION);
                            const { sorry, thisPassportExist } = getTraslations();
                            this.showAlert(sorry, thisPassportExist, ENUMS.ALERT_TYPES.ERROR);
                            reject();
                            this.updateStep(ENUMS.FormStep.MIGRATORY_INFORMATION);
                            this.informationMigratory[index].birthDate = birthDate;
                            this.informationMigratory[index].originFlightDate = originFlihtDate;
                            this.informationMigratory[index].embarcationDate = embarcationDate;
                        });
                    }
                    else if (model.id !== undefined) {
                        this.getAllCustoms().then(() => {
                            if (this.personalInformation.companions === index) {
                                this.updateStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                this.updateFrontStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                this.loadTabs();
                            }
                        });
                        resolved();
                    } else {
                        this.updateStep(1);
                        reject();
                    }
                });
            }).catch((err) => {
                if (err === invalidInputMessages.allInput) {
                    var { allFiledsRequired } = getTraslations();
                    this.showAlert("", allFiledsRequired, ENUMS.ALERT_TYPES.WARNING);
                } else if (err === invalidInputMessages.passport) {
                    var { invalidPassport } = getTraslations();
                    this.showAlert("", invalidPassport, ENUMS.ALERT_TYPES.WARNING);
                }
            });
        },
        updateMigratoryInformation(index) {
            var {
                updating,
                updated,
                passengerUpdated,
                errorTitle,
                passengerUpdatedError,
                allFiledsRequired,
                invalidPassport,
                awaitMoment
            } = getTraslations();

            var birthDate;
            var originFlighDate;
            var embarcationDate;
            return validateAllInputs(`content-tabs-${index}`).then(() => {
                this.isLoading(updating, awaitMoment);
                var model = this.informationMigratory[index];

                sessionStorage.setItem("embarkationPortText", model.embarkationPortText);
                sessionStorage.setItem("originPortText", model.originPortText);
                sessionStorage.setItem("disembarkationPortText", model.disembarkationPortText);

                birthDate = model.birthDate;
                originFlighDate = model.originFlightDate;
                embarcationDate = model.embarcationDate;

                //populateDates
                model.birthDate = moment(model.birthDate, "DD/MM/YYYY").toDate();
                model.originFlightDate = moment(model.originFlightDate, "DD/MM/YYYY").toDate();
                model.embarcationDate = moment(model.embarcationDate, "DD/MM/YYYY").toDate();
                model.nationality = String(model.nationality).toLocaleLowerCase();

                MigratoryInformationService.update(model).then((response) => {
                    if (response.status === 200) {
                        ///fix dates
                        this.informationMigratory[index].birthDate = birthDate;
                        this.informationMigratory[index].originFlightDate = originFlighDate;
                        this.informationMigratory[index].embarcationDate = embarcationDate;

                        this.showAlert(updated, passengerUpdated, ENUMS.ALERT_TYPES.SUCCESS).then(() => {
                            if (index < this.personalInformation.companions) {
                                this.pushingPersonMigratoryInformation(index);
                                goToTab(`content-tabs-${index + 1}`);
                                topContent();
                            } else {
                                this.updateStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                this.updateFrontStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                                topContent();
                            }
                        });
                        this.getAllCustoms();
                    } else {
                        this.showAlert(errorTitle, passengerUpdatedError, ENUMS.ALERT_TYPES.ERROR);
                    }
                }).catch(() => {
                    this.showAlert(errorTitle, passengerUpdatedError, ENUMS.ALERT_TYPES.ERROR);

                });
            }).catch((err) => {
                if (err === invalidInputMessages.allInput) this.showAlert("", allFiledsRequired, ENUMS.ALERT_TYPES.WARNING);
                else if (err === invalidInputMessages.passport) this.showAlert("", invalidPassport, ENUMS.ALERT_TYPES.ERROR);
            }).finally(() => {
                this.informationMigratory[index].birthDate = birthDate;
                this.informationMigratory[index].originFlightDate = originFlighDate;
                this.informationMigratory[index].embarcationDate = embarcationDate;
            });


        },
        removeMigratoryInformation(index) {
            var { deleting, deleted, passengerRemoved, errorTitle, errorHasOcurred, awaitMoment } = getTraslations();
            this.isLoading(deleting, awaitMoment);
            var model = this.informationMigratory[index];
            MigratoryInformationService.remove(model.id).then((response) => {
                if (response.status === 200) {
                    this.showAlert(deleted, passengerRemoved, ENUMS.ALERT_TYPES.SUCCESS);
                    this.informationMigratory = this.informationMigratory.filter(x => x.id !== model.id);
                    $(`#tab0`)[0].click();
                } else {
                    this.showAlert(errorTitle, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
                }
            }).catch(() => {
                this.showAlert(errorTitle, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
            });
            this.updateStep(1);
        },
        /**end personsmigratory */

        /**customs*/

        getAllCustoms() {

            return new Promise((resolved, reject) => {
                MigratoryInformationService.getApplicationCustoms(this.applicationId).then((response) => {
                    if (response.status === 200) {
                        this.customsInformations = response.data;
                        setTimeout(() => {
                            $('.tabs').tabs({
                                responsiveThreshold: Infinity,
                                swipeable: false
                            });

                        }, 2000);
                        resolved();
                    } else {
                        reject();
                    }
                }).catch(() => reject());
            });

        },
        createCustoms(index) {
            var model = this.customsInformations[index];
            model.customsInformation.applicationId = applicationId;
            model.customsInformation.migratoryInformationId = model.id;

            validateAllInputs(`customs-${index}`).then(() => {
                if (model.customsInformation.id === 0) {
                    this.saveCustom(model.customsInformation, index);
                } else {

                    this.updateCustom(model.customsInformation, index);
                }
            }).catch((e) => { console.log(e) });
        },
        createCustomsTab(index) {
            if (index <= 0) return;
            var model = this.customsInformations[index];
            model.customsInformation.applicationId = applicationId;
            model.customsInformation.migratoryInformationId = model.id;

            validateAllInputs(`customs-${index}`).then(() => {
                if (model.customsInformation.id === 0) {
                    this.saveCustomTab(model.customsInformation, index);
                } else {

                    this.updateCustomTab(model.customsInformation, index);
                }
            }).catch((e) => { console.log(e) });
        },
        saveCustomTab(model, index) {
            CustomInformationService.create(model).then((response) => {
                if (response.status === 200) {
                    this.customsInformations[index].customsInformation = response.data;
                    //click in next tab
                    if (this.customsInformations.length - 1 > index) {
                        topContent();
                    } else {
                        topContent();
                        this.getAllPublicHealths();
                        this.updateStep(ENUMS.FormStep.PUBLIC_HEALT);
                        this.updateFrontStep(ENUMS.FormStep.PUBLIC_HEALT);
                    }
                } else {
                    var { sorry, errorHasOcurred } = getTraslations();
                    this.showAlert(sorry, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
                    this.updateStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                }
            }).catch((e) => { console.log(e) });
        },
        saveCustom(model, index) {
            CustomInformationService.create(model).then((response) => {
                if (response.status === 200) {
                    this.customsInformations[index].customsInformation = response.data;
                    //click in next tab
                    if (this.customsInformations.length - 1 > index) {
                        goToTab(`customs-${index + 1}`);
                        topContent();
                    } else {
                        topContent();
                        this.getAllPublicHealths();
                        this.updateStep(ENUMS.FormStep.PUBLIC_HEALT);
                        this.updateFrontStep(ENUMS.FormStep.PUBLIC_HEALT);
                    }
                } else {
                    var { sorry, errorHasOcurred } = getTraslations();
                    this.showAlert(sorry, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
                    this.updateStep(ENUMS.FormStep.CUSTOMS_INFORMATION);
                }
            }).catch((e) => { console.log(e) });
        },
        updateCustom(model, index) {
            model.application = null;
            CustomInformationService.update(model).then(() => {
                if (this.customsInformations.length - 1 > index) {
                    goToTab(`customs-${index + 1}`);
                    topContent();
                } else {
                    topContent();
                    this.updateFrontStep(ENUMS.FormStep.PUBLIC_HEALT);
                    this.updateStep(ENUMS.FormStep.PUBLIC_HEALT);
                    this.getAllPublicHealths();
                }
            }).catch(() => {
                var { sorry, errorHasOcurred } = getTraslations();
                this.showAlert(sorry, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
            });
        },
        updateCustomTab(model, index) {
            model.application = null;
            CustomInformationService.update(model).then(() => {
                if (this.customsInformations.length - 1 > index) {
                    topContent();
                } else {
                    topContent();
                    this.updateFrontStep(ENUMS.FormStep.PUBLIC_HEALT);
                    this.updateStep(ENUMS.FormStep.PUBLIC_HEALT);
                    this.getAllPublicHealths();
                }
            }).catch(() => {
                var { sorry, errorHasOcurred } = getTraslations();
                this.showAlert(sorry, errorHasOcurred, ENUMS.ALERT_TYPES.ERROR);
            });
        },
        removeDeclaredMerch(index, declaredIndex) {
            var model = this.customsInformations[index].customsInformation;
            var declaredMerch = model.declaredMerchs[declaredIndex];
            if (declaredMerch.id !== undefined || declaredMerch.id > 0) {
                DeclaredMerchService.remove(declaredMerch.id);
                this.customsInformations[index].customsInformation.declaredMerchs = model.declaredMerchs.filter(x => x.id !== declaredMerch.id);
            } else {
                this.customsInformations[index].customsInformation.declaredMerchs = model.declaredMerchs.filter(x => x.codeX !== declaredMerch.codeX);
            }
        },
        /**end customs */

        /**
         * publicHealth
         */
        getAllPublicHealths() {
            PublicHealthService.getByApplicationId(applicationId).then((response) => {
                if (response.status === 200) {
                    this.publicHealth = response.data;
                    this.publicHealth.forEach((ph) => {
                        ph.publicHealth.publicHealthCountries = ph.publicHealth.publicHealthCountries.flatMap((value) => {
                            return {
                                id: value.id,
                                countryId: value.country.id,
                                iso2: value.country.iso2,
                                iso3: value.country.iso3,
                                name: value.country.name
                            };
                        });
                        ph.publicHealth.publicHealthStopOvers = ph.publicHealth.publicHealthStopOvers.flatMap((value) => {
                            return {
                                id: value.id,
                                countryId: value.country.id,
                                iso2: value.country.iso2,
                                iso3: value.country.iso3,
                                name: value.country.name
                            };
                        });
                        ph.publicHealth.questionResponse = ph.publicHealth.questionResponse.flatMap((value) => {
                            return {
                                BoolResponse: value.boolResponse,
                                QuestionId: value.questionId
                            };
                        });
                    });
                    this.loadTabs();
                }
            }).catch(() => { });
        },
        toCreatePublicHealth(indexArray) {
            var model = this.publicHealth[indexArray];
            model.publicHealth.applicationId = applicationId;
            model.publicHealth.migratoryInformationId = model.id;

            var simtoms = model.publicHealth.questionResponse.length > 0;
            if (simtoms) {
                validateAllInputs(`ph-${indexArray}`).then(() => {
                    this.savePublicHealth(model.publicHealth, indexArray);
                }).catch(() => { });
            } else {
                var { takeSintoms } = getTraslations();
                this.showAlert("", takeSintoms, ENUMS.ALERT_TYPES.WARNING);
            }
        },
        savePublicHealth(model, indexArray) {
            var date = model.symptomsDate;
            model.symptomsDate = moment(model.symptomsDate, "DD/MM/YYYY").toDate();
            PublicHealthService.create(model).then((response) => {
                if (response.status === 200) {
                    this.publicHealth[indexArray].publicHealth.id = response.data.id;
                    this.publicHealth[indexArray].publicHealth.symptomsDate = date;
                    this.publicHealth[indexArray].publicHealth.publicHealthsCountries = response.data.publicHealthCountries;
                    this.publicHealth[indexArray].publicHealth.publicHealthsStopOvers = response.data.publicHealthStopOvers;
                    if (this.publicHealth.length - 1 > indexArray) {
                        $('ul.tabs').tabs("select", `ph-${indexArray + 1}`);
                    } else {
                        this.wasHelpedMethod().then(() => { });
                    }
                }
            }).catch((err) => { });
        },
        updatePublicHealt(indexArray) {
            var { errorHasOcurred, takeSintoms } = getTraslations();
            var model = this.publicHealth[indexArray];
            var date = model.publicHealth.symptomsDate;
            model.publicHealth.symptomsDate = moment(model.publicHealth.symptomsDate, "DD/MM/YYYY").toDate();
            model.publicHealth.applicationId = Number(applicationId);
            model.publicHealth.application = null;
            var simtoms = model.publicHealth.questionResponse.length > 0;
            if (simtoms) {
                PublicHealthService.update(model.publicHealth).then(() => {
                    if (this.publicHealth.length - 1 > indexArray) {
                        $('ul.tabs').tabs("select", `ph-${indexArray + 1}`);
                    } else {
                        this.wasHelpedMethod().then(() => { });
                    }
                }).catch(() => this.showAlert("", errorHasOcurred, ENUMS.ALERT_TYPES.ERROR))
                    .finally(() => {
                        model.publicHealth.symptomsDate = date;
                    });
            } else {
                this.showAlert("", takeSintoms, ENUMS.ALERT_TYPES.WARNING);
            }
        },
        /*en public health*/

        /**
         * this method call a alert with form if you was helped to completed a form
         * */
        async wasHelpedMethod() {
            var questionResponse = await this.wasHelpedQuestion();
            if (questionResponse.value) {
                var { value } = await this.wasHelpedForm();
                if (value) {
                    var name = $("#wname").val();
                    var relationShip = $("#wrelationShip").val();
                    var valid = name.trim().length > 0 && relationShip.trim().length > 0;
                    if (valid) {
                        //send value to api//
                        var model = {
                            ApplicationId: applicationId,
                            AssistantName: name,
                            AssistantRelation: relationShip
                        };

                        try {
                            await CommonsService.saveWasHelped(model);
                            this.accepTerms();
                        } catch (e) {
                            console.log(e)
                            this.showAlert("Error", "intenta nuevamente", "error");
                            return;
                        }

                    } else {
                        await this.showRequiredFielAlert();
                        return;
                    }
                } else {
                    return;
                }
            }
            this.accepTerms();

        },

        async showRequiredFielAlert() {
            var { allFiledsRequired } = getTraslations();
            await Swal.fire({
                title: allFiledsRequired,
                type: ENUMS.ALERT_TYPES.ERROR,
                showConfirmButton: true,
                showCancelButton: false,
                confirmButtonText: "Ok",
            })
        },

        /**
         * show alert with question if was helped
         * */
        async wasHelpedQuestion() {
            var { wasHelpedText, yes, not } = getTraslations();

            return await Swal.fire({
                title: wasHelpedText,
                type: ENUMS.ALERT_TYPES.INFO,
                showConfirmButton: true,
                showCancelButton: true,
                confirmButtonText: yes,
                cancelButtonText: not,
            })
        },

        /**
         * show alert with form help */
        async wasHelpedForm() {

            var { fillInformationHelpedForm, yes, cancel, fullName, Relationship } = getTraslations();

            var form = `<div class="container" style="margin-top:30px !important;">
                            <div>
                                <label>${fullName}</label>
                                <input id="wname" /> 
                            </div>
                            <div>
                                <label>${Relationship}</label>
                                <input id="wrelationShip" />
                            </div>
                          </div>`;
            return await Swal.fire({
                title: fillInformationHelpedForm,
                type: ENUMS.ALERT_TYPES.INFO,
                html: form,
                showConfirmButton: true,
                showCancelButton: true,
                confirmButtonText: yes,
                cancelButtonText: cancel,
            });
        },

        /**
         * 
         * acceptsTerms methods!
         */
        accepTerms() {
            var { acceptTermsTitle, aceptTermDgaText, aceptTermDgmText, aceptTermMSP } = getTraslations();


            var html = `<div> 
                                <img src="/img/DGA.png" style="margin-bottom:-40px;" width="250"/> </br>
                                <p style="margin-bottom:-10px;">${aceptTermDgaText}</p> </br>
                                <img src="/img/dgm.png"  width="225"/> </br>
                                <p style="margin-bottom:-10px;" >${aceptTermDgmText}</p> </br>
                                <img src="/img/logomsp.png"   width="225" /> </br>
                                <p style="margin-bottom:-10px;" >${aceptTermMSP}</p> </br>
                          </div>`;

            Swal.fire({
                title: acceptTermsTitle,
                html: html,
                type: ENUMS.ALERT_TYPES.INFO,
                showConfirmButton: true,
                showCancelButton: true
            }).then((result) => {
                if (result.value) {
                    const token = window.location.search;
                    CommonsService.acceptTerms(applicationId).then(() => {
                        new Promise((resolved, _) => {
                            resolved();
                        }).then(() => {
                            this.updateStep(4);
                            setTimeout(function () { document.location.href = `/travelticket/ticketemision${token}`; }, 250);
                        });
                    });
                }
            }).catch((e) => { console.log(e) });

        },
        /**
         * end acceptsTerms
         */
        /*end api calls*/

        /*events */
        addMoreWares(index) {
            this.customsInformations[index].customsInformation.declaredMerchs.push({ description: null, dollarValue: 1, codeX: `${Math.random().toString(36).substring(7)}-cd` });
        },
        addToVisitCountry(id, indexArray) {
            var result = this.countries.find(x => x.id === id);
            var country = {
                countryId: id,
                iso2: result.iso2,
                iso3: result.iso3,
                name: result.name,
                officialName: result.officialName
            };
            if (this.publicHealth[indexArray].publicHealth.publicHealthCountries.filter(x => x.countryId === id).length === 0) {
                this.publicHealth[indexArray].publicHealth.publicHealthCountries.push(country);
            }
        },
        addToVisitLastCountry(id, indexArray) {
            var result = this.countries.find(x => x.id === id);
            var country = {
                countryId: id,
                iso2: result.iso2,
                iso3: result.iso3,
                name: result.name,
                officialName: result.officialName
            };
            if (this.publicHealth[indexArray].publicHealth.publicHealthStopOvers.filter(x => x.countryId === id).length === 0) {
                this.publicHealth[indexArray].publicHealth.publicHealthStopOvers.push(country);
            }
        },
        removeCountryVisited(id, indexArray, indexCountry) {
            var { errorHasOcurred } = getTraslations();
            var model = this.publicHealth[indexArray].publicHealth;
            var Entity = model.publicHealthCountries[indexCountry];
            if (Entity.id !== undefined) {
                PublicHealthService.removeHealthCountry(Entity.id).then(() => {
                    this.publicHealth[indexArray].publicHealth.publicHealthCountries = model.publicHealthCountries.filter(x => x.countryId !== id);
                }).catch(() => this.showAlert("", errorHasOcurred, ENUMS.ALERT_TYPES.ERROR));
            } else {
                this.publicHealth[indexArray].publicHealth.publicHealthCountries = model.publicHealthCountries.filter(x => x.countryId !== id);
            }
        },
        removeCountryLastVisited(id, indexArray, indexCountry) {
            var { errorHasOcurred } = getTraslations();
            var model = this.publicHealth[indexArray].publicHealth;
            var Entity = model.publicHealthStopOvers[indexCountry];
            if (Entity.id !== undefined) {
                PublicHealthService.removeHealthCountryStopOver(Entity.id).then(() => {
                    this.publicHealth[indexArray].publicHealth.publicHealthStopOvers = model.publicHealthStopOvers.filter(x => x.countryId !== id);
                }).catch(() => this.showAlert("", errorHasOcurred, ENUMS.ALERT_TYPES.ERROR));
            }
            else {
                this.publicHealth[indexArray].publicHealth.publicHealthStopOvers = model.publicHealthStopOvers.filter(x => x.countryId !== id);
            }
        },

        addQuestionResponseToPublicHealth(idQuestion, indexArray) {
            var publicHealth = this.publicHealth[indexArray].publicHealth;
            var question = {
                QuestionId: idQuestion, ///fix object
                BoolResponse: true
            };
            if (publicHealth.questionResponse.filter(x => x.QuestionId === idQuestion).length === 0) {
                publicHealth.questionResponse.push(question);
            } else {
                publicHealth.questionResponse = publicHealth.questionResponse.filter(x => x.QuestionId !== idQuestion);
            }
        },
        pushingPersonMigratoryInformation(indexArray) {
            var {
                sorry,
                needAllFieldsPeople,
                checkPersonfields,
                allFiledsRequired,
                invalidPassport
            } = getTraslations();
            loadSelect(0);
            var model = this.informationMigratory[indexArray];

            validateAllInputs(`content-tabs-${indexArray}`).then(() => {
                var result = this.createMigratoryInformation();
                var lastPosition = this.informationMigratory.length - 1;
                result.then(() => {
                    if (this.informationMigratory[indexArray].id !== undefined) {
                        if (this.informationMigratory.length <= this.personalInformation.companions) {
                            this.informationMigratory.push({
                                names: null,
                                lastNames: null,
                                birthDate: null,
                                gender: 'M',
                                nationality: null,
                                birthPlace: null,
                                isPrincipal: false,
                                passportNumber: null,
                                documentIdNumber: null,
                                maritalStatusId: null,
                                ocupationId: null,
                                hotelId: null,
                                geoCode: null,
                                street: null,
                                originPort: null,
                                originFlightNumber: null,
                                originFlightDate: null,
                                embarkationPort: null,
                                embarcationFlightNumber: null,
                                embarcationDate: null,
                                disembarkationPort: null,
                                disembarkationFligthNumber: null,
                                flightMotiveId: null,
                                transportationCompany: null,
                                daysOfStaying: 1,
                                specificFlightMotive: null,
                                hasCommonAddress: true,
                                applicationId: applicationId,
                                confirmationNumber: null,
                                email: null,
                                sector: {
                                    province: null,
                                    municipalities: null
                                },
                                hasCommonHotel: true
                            });
                            if (lastPosition === indexArray) {
                                setTimeout(() => {
                                    $(`#tab${indexArray + 1}`)[0].click();
                                }, 100);
                            }
                        }
                    } else {
                        this.updateStep(1);
                        this.showAlert(sorry, String(needAllFieldsPeople).replace("{0}", `${indexArray + 1}`), ENUMS.ALERT_TYPES.WARNING);
                    }
                }).catch(() => {
                    this.updateStep(1);
                    this.showAlert(sorry, String(checkPersonfields).replace("{0}", `${indexArray + 1}`), ENUMS.ALERT_TYPES.WARNING);
                });
            }).catch((error) => {
                console.log(error);
                if (error === invalidInputMessages.allInput) {
                    this.showAlert("", allFiledsRequired, ENUMS.ALERT_TYPES.WARNING);
                } else if (error === invalidInputMessages.passport) {
                    this.showAlert(ENUMS.ALERT_TYPES.INFO, invalidPassport, ENUMS.ALERT_TYPES.ERROR);
                }
            });

        },
        isLoading(title = "Cargando...", text = "espere un momento") {
            Swal.fire({
                title: title,
                text: text,
                showConfirmButton: false
            });
            Swal.showLoading();
        },
        showAlert(title = "", text = "", type = ENUMS.ALERT_TYPES.SUCCESS) {
            return Swal.fire({
                title: title,
                text: text,
                type: type
            });
        },
        morePerson() {
            if (this.informationMigratory.length < this.personalInformation.companions + 1) {
                var { remeberCompleteAllPassengers } = getTraslations();
                this.showAlert("", remeberCompleteAllPassengers, ENUMS.ALERT_TYPES.INFO);
            }
        },
        updateFrontStep(index) {
            stepperInstace.openStep(index);
            setDoneStepper(index);
            topContent();
        },
        loadTabs() {
            //setTimeout(() => {
            //    const tabs = $('.tabs li .clickeadble');
            //    for (let i = tabs.length - 1; i >= 0; i--) {
            //        tabs[i].click();
            //    }
            //    document.documentElement.scrollTop = 200;
            //}, 500);

        },
        lastCompanion() {
            return this.personalInformation.companions;
        },
        showDatePicker(id) {
            var { months,
                weekdays,
                weekdaysAbbrev,
                weekdaysShort } = getTraslations();
            $('.datepicker-Flight').datepicker({
                i18n: {
                    months,
                    weekdays,
                    weekdaysAbbrev,
                    weekdaysShort
                },
                setDefaultDate: true,
                yearRange: [1910, new Date().getFullYear()],
                format: "dd/mm/yyyy",
                maxDate: new Date()
            });
            $('.datepicker').keypress(function (e) {
                e.preventDefault();
            });
            $(id).datepicker('open');
        },
        /**
         * valida que el pasaporte y el campo confirm passport
         * @param {any} indexArray indice del array de migratoryInformation
         */
        passportConfirmedIsValid(indexArray) {
            var info = this.informationMigratory[indexArray];
            return info.passportNumber === info.passportNumberConfirm;
        }

        , addPortIn(id, key, portname) {
            this.informationMigratory[key].embarkationPortNavId = id;
            var result = this.intPorts.find(x => x.id === id);
            var index = this.intPorts.indexOf(result)
            this.informationMigratory[key].embarkationPortText = index + 1;
        },
        addPortIntOrigin(id, key, portname) {
            this.informationMigratory[key].originPortNavId = id;
            var result = this.intPorts.find(x => x.id === id);
            var index = this.intPorts.indexOf(result)
            this.informationMigratory[key].originPortText = index + 1;
        },
        addPortIntDisembarkation(id, key) {
            this.informationMigratory[key].disembarkationPortNavId = id;
            var result = this.intPorts.find(x => x.id === id);
            var index = this.intPorts.indexOf(result)
            this.informationMigratory[key].disembarkationPortText = index + 1;
        },
        needCompleteAllCustoms(index, event) {
            if (index > 0) {
                var list = this.customsInformations.slice(0, index);
                list.forEach((custom) => {
                    if (custom.customsInformation.id <= 0 || custom.customsInformation.id === null || custom.customsInformation.id === undefined) {
                        event.stopPropagation();
                    }
                });

            }

        },
        needCompleteAllpublicHealth(index, event) {
            if (index > 0) {
                const list = this.publicHealth.slice(0, index);
                list.forEach((pb) => {
                    if (pb.publicHealth.id <= 0 || pb.publicHealth.id === null || pb.publicHealth.id === undefined) {
                        event.stopPropagation();
                    }
                });

            }

        }
        ,
        addHotel(id, personIndex) {
            this.informationMigratory[personIndex].hotelId = id;
        },
        addCity(id) {
            this.personalInformation.cityId = id;
            this.personalInformation.cityOfResidence = this.cities.find(x => x.id === id).name;
            this.personalInformation.state = this.cities.find(x => x.id === id).state;
        },
        getHotelName(id) {
            var result = this.hotels.find(x => x.id === id);
            if (!result) return "";
            return result.name;
        },
        async getCities() {
            try {
                //var result = await CommonsService.getCities(this.personalInformation.selectedNat);
                //this.cities = result.data;
                this.personalInformation.cityId = null;
                this.personalInformation.cityOfResidence = null;
                this.personalInformation.state = null;
                this.personalInformation.countryResidence = this.countries.find(x => x.iso2 === this.personalInformation.selectedNat).name;
                this.cities = [];
            } catch (e) {
                console.log(e)
            }

        },
        async getCityByName() {
            var cityName = this.searchCity.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase().trim();
            if (cityName.length < 2) return;
            Swal.showLoading();
            var result = await CommonsService.getCitiesbyName(this.personalInformation.selectedNat, cityName);
            this.cities = result.data;
            Swal.close()
        }



    },
    computeds: {
        getOtherAirline() {
            var result = this.airlines.find(x => x.code === 'XX');
            if (result === undefined) return 0;
            else return result.id;
        },
        getOtherPort() {
            var result = this.ports.find(x => x.code === 'XXX');
            if (result === undefined) return null;
            else return result.id;
        },
        getOtherPortOrigin() {
            var result = this.ports.find(x => x.code === 'XXX');
            if (result === undefined) return 0;
            else return result.id;
        },
        isMoreOfSix() {
            if (this.informationMigratory.length >= 6) return "s1";
            else if (this.informationMigratory.length >= 5) return "s2";
            else return "s3";
        },
        visitedCountry() {
            var search = this.searchCountryVisit.toLowerCase().trim();

            if (!search) return this.countries;

            return this.countries.filter(c => c.name.toLowerCase().indexOf(search) > -1);
        },
        visitedlastCountry() {
            var search = this.searchCountrylastVisit.toLowerCase().trim();

            if (!search) return this.countries;

            return this.countries.filter(c => c.name.toLowerCase().indexOf(search) > -1);
        },
        isLastElementCustoms() {
            return this.customsInformations.length - 1;
        },
        isIn() {
            return this.publicHealth[0].application.genericInformation.isArrival;
        },
        isArrival() {
            return this.personalInformation.isArrival;
        },
        portIntResuls() {
            var search = this.searchIntPorts.toLowerCase().trim();

            if (!search) return [];

            return this.intPorts.filter(c => `${c.name} ${c.code}`.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase().indexOf(search) > -1).slice(0, 100);
        },
        HotelsResults() {
            var search = this.searchHotels.toLowerCase().trim();

            if (!search) return [];

            return this.hotels.filter(c => c.name.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase().indexOf(search) > -1).slice(0, 200);
        }
        ,
        cityResults() {
            var search = this.searchCity.toLowerCase().trim();
            if (!search) return [];
            return this.cities;

            //return this.cities.filter(c => c.name.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase().indexOf(search) > -1).slice(0, 200);
        }
    }
};