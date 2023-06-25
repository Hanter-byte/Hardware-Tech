// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(document).ready(function () {
    $('#myTable').DataTable({
        "ordering": true,
        "paging": true,
        "autoWidth": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
});

//$(document).ready(function () {
//    var TableManutencao1 = $('#TableManutencao1').DataTable({
//        "ordering": true,
//        "paging": true,
//        "autoWidth": true,
//        "searching": true,
//        "oLanguage": {
//            "sEmptyTable": "Nenhum registro encontrado na tabela",
//            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
//            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
//            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
//            "sInfoPostFix": "",
//            "sInfoThousands": ".",
//            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
//            "sLoadingRecords": "Carregando...",
//            "sProcessing": "Processando...",
//            "sZeroRecords": "Nenhum registro encontrado",
//            "sSearch": "Pesquisar",
//            "oPaginate": {
//                "sNext": "Proximo",
//                "sPrevious": "Anterior",
//                "sFirst": "Primeiro",
//                "sLast": "Ultimo"
//            },
//            "oAria": {
//                "sSortAscending": ": Ordenar colunas de forma ascendente",
//                "sSortDescending": ": Ordenar colunas de forma descendente"
//            }
//        },
//        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
//        "pageLength": 5
//    });

//    $('#TableManutencao1 tbody').on('click', 'tr', function () {
//        if ($(this).hasClass('selected')) {
//            $(this).removeClass('selected');
//        } else {
//            TableManutencao1.$('tr.selected').removeClass('selected');
//            $(this).addClass('selected');
//        }
//    });

//});

//$(document).ready(function () {
//    var TableManutencao2 = $('#TableManutencao2').DataTable({
//        "ordering": true,
//        "paging": true,
//        "autoWidth": true,
//        "searching": true,
//        "oLanguage": {
//            "sEmptyTable": "Nenhum registro encontrado na tabela",
//            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
//            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
//            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
//            "sInfoPostFix": "",
//            "sInfoThousands": ".",
//            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
//            "sLoadingRecords": "Carregando...",
//            "sProcessing": "Processando...",
//            "sZeroRecords": "Nenhum registro encontrado",
//            "sSearch": "Pesquisar",
//            "oPaginate": {
//                "sNext": "Proximo",
//                "sPrevious": "Anterior",
//                "sFirst": "Primeiro",
//                "sLast": "Ultimo"
//            },
//            "oAria": {
//                "sSortAscending": ": Ordenar colunas de forma ascendente",
//                "sSortDescending": ": Ordenar colunas de forma descendente"
//            }
//        },
//        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
//        "pageLength": 5
//    });

//    $('#TableManutencao2 tbody').on('click', 'tr', function () {
//        if ($(this).hasClass('selected')) {
//            $(this).removeClass('selected');
//        } else {
//            TableManutencao2.$('tr.selected').removeClass('selected');
//            $(this).addClass('selected');
//        }
//    });
//});

//function passIdCliente(idCliente) {
//    document.getElementById('idCliente').value = idCliente;
//}

//function passIdLivro(idLivro) {
//    document.getElementById('idLivro').value = idLivro;
//}