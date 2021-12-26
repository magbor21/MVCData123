function listTheEFPeople() {
    $.get("/EntityFramework/ListPeople", null, function (data) {
        $("#PersonEFList").html(data);
    });
}


function deleteEFId(element, num) {
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

function listTheEFCountries() {
    $.get("/Country/ListCountries", null, function (data) {
        $("#CountryEFList").html(data);
    });
}

function createCityView() {
    $.get("/City/CreateView", null, function (data) {
        $("#CityEFList").html(data);
    });
}