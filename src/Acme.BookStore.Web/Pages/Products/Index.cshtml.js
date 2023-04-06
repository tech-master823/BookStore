$(function () {
    var l = abp.localization.getResource('BookStore');
    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, 'asc']],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                acme.bookStore.products.product.getList
            ),
            columnDefs: [
                /* TODO: Column definitions */
                {
                    title: l('Name'),
                    data: 'name',
                },
                {
                    title: l('CategoryName'),
                    data: 'categoryName',
                    orderable: false,
                },
                {
                    title: l('Price'),
                    data: 'price',
                },
                {
                    title: l('StockState'),
                    data: 'stockState',
                    render: function (data) {
                        return l('Enum:StockState:' + data);
                    },
                },
                {
                    title: l('CreationTime'),
                    data: 'creationTime',
                    dataFormat: 'date',
                },
            ],
        })
    );
});
