var CommonsService = {
    getAllReasons() {
        return axios.get('/api/FlightMotives');
    },
    getAllHotels() {
        return axios.get('/api/Hotels');
    },
    getCurrency() {
        return axios.get('/api/Currencies');
    },
    getAllOcupations() {
        return axios.get('/api/Ocupations');
    },
    getAllMeritalStatuses() {
        return axios.get('/api/MaritalStatus');
    },
    updateStep(model) {
        return axios.put("/api/Application/UpdateStep", model);
    },
    getAllQuetions(step, module) {
        return axios.get(`/api/Questions/${step}/${module}`);
    },
    acceptTerms(applicationId) {
        return axios.put(`/api/Application/AcceptTerms/${applicationId}`);
    },
    getAllAirlines() {
        return axios.get("/api/airline");
    },
    getIntPorts(trasnportId) {
        //enviar luego
        return axios.get(`/api/port/GetByTransportation/`);
    },
    getIntById(id) {
        //enviar luego
        return axios.get(`/api/port/${id}`);
    },
    getListPorts(trasnportId, name) {
        return axios.get(`/api/port`);
    },
    async getAllPortsByTransportationId(id) {
        return await axios.get(`/api/port/GetAllDomPorts/${id}`);
    },
    async saveWasHelped(model) {
        return await axios.put("/api/Application/AssistedInfo", model);
    },
    async getCities(iso2) {
        return await axios.get(`/api/City/GetByIso2/${iso2}`);
    },
    async getCitiesbyName(iso2,name) {
        return await axios.get(`/api/City/GetByName/${iso2}/${name}`);
    }
};


var TransportationService = {
    getAllTransportationMethods() {
        return axios.get('/api/Transportation');
    }
};


var GeoLocationService = {
    getAllContries() {
        return axios.get('/api/Countries');
    },
    getAllProvinces() {
        return axios.get('/api/GeoCode/GetProvinces');
    },
    getMunicipalities(provinceIdSelected) {
        return axios.get(`/api/GeoCode/GetMunicipalities/${provinceIdSelected}`);
    },
    getSectors(provinceId, monicipalityCode) {
        return axios.get(`/api/GeoCode/GetSectors/${provinceId}/${monicipalityCode}`);
    }
};


var PersonalInformationService = {
    update(model) {
        return axios.put('/api/GeneralInformation', model);
    },
    getByApplicationId(applicationId) {
        return axios.get(`/api/GeneralInformation/GetByApplicationId/${applicationId}`);
    }
};

var MigratoryInformationService = {
    getAllPersons(applicationId) {
        return axios.get(`/api/MigratoryInformation/GetByApplicationId/${applicationId}`);
    },
    create(model) {
        return axios.post('/api/MigratoryInformation/DispatchCreation', model);
    },
    update(model) {
        return axios.put('/api/MigratoryInformation/DispatchUpdate', model);
    },
    remove(id) {
        return axios.delete(`/api/MigratoryInformation/${id}`);
    },
    getApplicationCustoms(applicationId) {
        return axios.get(`/api/MigratoryInformation/GetInfoToCustoms/${applicationId}`);
    }
};

var CustomInformationService = {
    create(model) {
        return axios.post(`/api/Customs`, model);
    },
    update(model) {
        return axios.put('api/Customs', model);
    }
};

var DeclaredMerchService = {
    remove(id) {
        return axios.delete(`/api/DeclaredMerch/${id}`);
    }
};

var PublicHealthService = {
    getByApplicationId(id) {
        return axios.get(`/api/MigratoryInformation/GetInfoToPublicHealth/${id}`);
    },
    create(model) {
        return axios.post('/api/PublicHealth', model);
    },
    update(model) {
        return axios.put("/api/PublicHealth", model);
    },
    removeHealthCountry(id) {
        return axios.delete(`/api/PublicHealthCountries/${id}`);
    },
    removeHealthCountryStopOver(id) {
        return axios.delete(`/api/PublicHealthStopOver/${id}`);
    }
};

