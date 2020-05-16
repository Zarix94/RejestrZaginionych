function generatePopupHtml(data) {
    console.log(data);

    var html = '';
    html += '<div style="font-size: 14px;">';
    html += '<img style="width: 200px; height: 300px;"src="' + data.ImagePath + '" />';
    if (data.DistinguishingMarks != '') {
        html += '<div style="text-align: left;"><strong>Znaki szczególne:</strong></div>';
        html += '<div style="text-align: left; padding-bottom: 5px;">' + data.DistinguishingMarks + '</div>';
    }

    if (data.Description != '') {
        html += '<div style="text-align: left;"><strong>Opis:</strong></div>';
        html += '<div style="text-align: left;">' + data.Description +'</div>';
    }

    html += '</div>';



    return html}


$(document).ready(function () {
    $('#MissingPersonList').DataTable({
        language: {
            search: "Szukaj",
            lengthMenu: "Wyświetlono _MENU_ wierszów",
            info: "Wyświetlono od _START_ wiersza do  _END_ z _TOTAL_",
            paginate: {
                first: "Pierwsza",
                previous: "Poprzednia",
                next: "Następna",
                last: "Ostatnia"
            },
        }
    });

    $('.missingPersonRow').each(function (idx, elm) {
        $(elm).click(function () {
            var attr = $(this).attr('data-person-id');
            $.post('MissingPerson/GetPopUpData', {
                personId: attr
            }, function (data) {

                Swal.fire({
                    title: data.Name + ' (' + data.Age + '), ' + data.City,
                    html: generatePopupHtml(data),
                    confirmButtonText: 'Zamknij'
                })
            });



        });
    });
   
});