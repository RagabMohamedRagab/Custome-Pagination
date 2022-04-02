////$(document).ready(function () {
////    $("#Customers").DataTable({
////        "processing": true,
////        "serverSide": true,
////        "filter": true,
////        "Ajax": [{
////            "url": "/api/Customer",
////            "type": "POST",
////            "datatype": "json"
////        }],
////        "columns": [
////            { "data": "id " },
////            { "data": "firstName", "name":"FirstName", "autoWidth": true },
////            { "data": "lastName", "name": "LastName", "autoWidth": true},
////            { "data": "contact", "name": "Contact","autoWidth": true },
////            { "data": "email", "name": "Email","autoWidth": true},
////            { "data": "dataBirth", "name": "DataBirth", "autoWidth": true},
////            {
////                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=DeleteCustomer('" + row.id + "'); >Delete</a>"; }
////            },
////        ]
////    });
////});  