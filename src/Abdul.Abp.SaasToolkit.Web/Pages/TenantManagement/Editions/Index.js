(function () {
    var l = abp.localization.getResource('AbpTenantManagement');
    var _editionAppService = volo.abp.tenantManagement.edition;

    var _editModal = new abp.ModalManager(
        abp.appPath + 'TenantManagement/Editions/EditModal'
    );
    var _createModal = new abp.ModalManager(
        abp.appPath + 'TenantManagement/Editions/CreateModal'
    );
    var _featuresModal = new abp.ModalManager(
        abp.appPath + 'FeatureManagement/FeatureManagementModal'
    );

    var _dataTable = null;

    abp.ui.extensions.entityActions.get('tenantManagement.edition').addContributor(
        function (actionList) {
            return actionList.addManyTail(
                [
                    {
                        text: l('Edit'),
                        visible: abp.auth.isGranted(
                            'AbpTenantManagement.Editions.Update'
                        ),
                        action: function (data) {
                            _editModal.open({
                                id: data.record.id,
                            });
                        },
                    },
                    {
                        text: l('Features'),
                        visible: abp.auth.isGranted(
                            'AbpTenantManagement.Editions.ManageFeatures'
                        ),
                        action: function (data) {
                            _featuresModal.open({
                                providerName: 'E',
                                providerKey: data.record.id,
                            });
                        },
                    },
                    {
                        text: l('Delete'),
                        visible: abp.auth.isGranted(
                            'AbpTenantManagement.Editions.Delete'
                        ),
                        confirmMessage: function (data) {
                            return l(
                                'EditionDeletionConfirmationMessage',
                                data.record.name
                            );
                        },
                        action: function (data) {
                            _editionAppService
                                .delete(data.record.id)
                                .then(function () {
                                    _dataTable.ajax.reload();
                                });
                        },
                    }
                ]
            );
        }
    );

    abp.ui.extensions.tableColumns.get('tenantManagement.edition').addContributor(
        function (columnList) {
            columnList.addManyTail(
                [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: abp.ui.extensions.entityActions.get('tenantManagement.edition').actions.toArray()
                        }
                    },
                    {
                        title: l("EditionName"),
                        data: 'displayName',
                    }
                ]
            );
        },
        0 //adds as the first contributor
    );

    $(function () {
        var _$wrapper = $('#EditionsWrapper');

        _dataTable = _$wrapper.find('table').DataTable(
            abp.libs.datatables.normalizeConfiguration({
                order: [[1, 'asc']],
                processing: true,
                paging: true,
                scrollX: true,
                serverSide: true,
                ajax: abp.libs.datatables.createAjax(_editionAppService.getList),
                columnDefs: abp.ui.extensions.tableColumns.get('tenantManagement.edition').columns.toArray(),
            })
        );

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _$wrapper.find('button[name=CreateEdition]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });
})();
