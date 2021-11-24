function listThePeople() {
    $.get("/Ajax/ListPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}

function detailsView() {
    var personIDValue = document.getElementById('personIdInput').value;
    $.post("/Ajax/PersonDetails", { personID: personIDValue }, function (data) {
        $("#PersonList").html(data);
    });
}

function deleteId() {
    var personIDValue = document.getElementById('personIdInput').value;
    $.post("/Ajax/PersonDelete", { personID: personIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Successfully Deleted Person.";
            listThePeople();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could not delete the person.";
        });
}
