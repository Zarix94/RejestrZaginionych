$(document).ready(function () {
    $('#UserList').DataTable({
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
});