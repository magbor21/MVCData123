
function listTheEFCountries() {
    $.get("/EntityFramework/ListCountries", null, function (data) {
        $("#countryEFList").html(data);
    });
}

function listTheEFCities() {
    $.get("/EntityFramework/ListCities", null, function (data) {
        $("#cityEFList").html(data);
    });
}

function listTheEFPeople() {
    $.get("/EntityFramework/ListPeople", null, function (data) {
        $("#personEFList").html(data);
    });
}


function deleteEFPersonId(element, num) {
    var personIDValue = num;
    $.post("/EntityFramework/PersonDelete", { personID: personIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorEFMessages').innerHTML = "Successfully Deleted Person.";
            listTheEFPeople();
        })
        .fail(function () {
            document.getElementById('errorEFMessages').innerHTML = "Could not delete the person.";
        });
}

function deleteEFCityId(element, num) {
    var cityIDValue = num;
    $.post("/EntityFramework/CityDelete", { cityID: cityIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorEFMessages').innerHTML = "Successfully Deleted City.";
            listTheEFCities();
        })
        .fail(function () {
            document.getElementById('errorEFMessages').innerHTML = "Could not delete the city.";
        });
}

function deleteEFCountryId(element, num) {
    var countryIDValue = num;
    $.post("/EntityFramework/CountryDelete", { countryID: countryIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorEFMessages').innerHTML = "Successfully Deleted Country.";
            listTheEFCountries();
        })
        .fail(function () {
            document.getElementById('errorEFMessages').innerHTML = "Could not delete the country.";
        });
}

function countryDetails(element, num) {
    var countryIDValue = num;
    $.post("/EntityFramework/CountryDetails", { countryID: countryIDValue }, function (data) {
        $("#countryEFList").html(data);
    });
}

function cityDetails(element, num) {
    var cityIDValue = num;
    $.post("/EntityFramework/CityDetails", { cityID: cityIDValue }, function (data) {
        $("#cityEFList").html(data);
    });
}