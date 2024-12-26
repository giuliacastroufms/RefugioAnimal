$(document).ready(function () {
    $('#getAllAnimalsButton').click(function () {
        $.ajax({
            url: '/Animal/GetAllAnimals',
            type: 'GET',
            success: function (data) {
                var animalsList = $('#animalsList');
                animalsList.empty();
                if (data && data.length > 0) {
                    var list = $('<ul></ul>');
                    $.each(data, function (index, animal) {
                        list.append(
                            '<li> Id - ' + animal.id + '</li>' +
                            '<li> Name - ' + animal.name + '</li>' +
                            '<li> Description - ' + animal.description + '</li>' +
                            '<li> Specie - ' + animal.specie + '</li>' +
                            '<li> AdoptionStatus - ' + animal.adoptionStatus + '</li>'
                        );
                    });
                    animalsList.append(list);
                } else {
                    animalsList.append('<p>No animals found.</p>');
                }
            },
            error: function (xhr, status, error) {
                $('#animalsList').html('<p>Error retrieving data: ' + error + '</p>');
            }
        });
    });

    $('#createAnimalForm').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '/Animal/CreateAnimal',
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                $('#createResult').html('Animal created successfully');
                $('#createAnimalForm')[0].reset();
            },
            error: function (xhr, status, error) {
                $('#createResult').html('<p>Error creating animal: ' + error + '</p>');
            }
        });
    });

    $('#editAnimalForm').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '/Animal/EditAnimal',
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                $('#editResult').html('Animal updated successfully');
            },
            error: function (xhr, status, error) {
                $('#editResult').html('<p>Error updating animal: ' + error + '</p>');
            }
        });
    });

    $('#deleteAnimalForm').submit(function (event) {
        event.preventDefault();
        $.ajax({
            url: '/Animal/DeleteAnimal',
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                $('#deleteResult').html('Animal deleted successfully');
            },
            error: function (xhr, status, error) {
                $('#deleteResult').html('<p>Error deleting animal: ' + error + '</p>');
            }
        });
    });
});
