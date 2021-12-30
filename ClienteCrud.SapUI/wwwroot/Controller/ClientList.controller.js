sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/m/MessageBox"
], function (Controller, JSONModel, Filter, FilterOperator, MessageBox) {
	"use strict";

	return Controller.extend("sap.ui.crudCliente.Controller.ClientList", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("overview").attachPatternMatched(this._onObjectMatched, this);
		},
		onBeforeRendering: function () {
			var oBusyDialog = new sap.m.BusyDialog("oBusyDialog");
			oBusyDialog.open();
		},

		_onObjectMatched: function () {
			var that = this;
			$.ajax({
				dataType: "json",
				type: "GET",
				url: "https://localhost:5001/api/Cliente/Index",
				success: function (response) {
					sap.ui.getCore().getElementById("oBusyDialog").close();
					var oViewModel = new JSONModel({ Client: response })
					that.getView().setModel(oViewModel, "client")
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					MessageBox.show("Erro ao gerar a tabela: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").close();
				}
			})
		},
		onFilterClient: function (oEvent) {
			// build filter array
			var nFilter = [];
			var sQuery = oEvent.getParameter("query");
			if (sQuery) {
				nFilter.push(new Filter("nome", FilterOperator.Contains, sQuery));
			}

			// filter binding
			var oTable = this.byId("ClientTable");
			var oBinding = oTable.getBinding("items");
			oBinding.filter(nFilter);
        },
		onCreate : function () {
			this.getOwnerComponent().getRouter().navTo("create");
		},
		onEdit : function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("edit", {
				data: IdView
			});
		},
		onDetail: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			var IdView = selectedClient.id;
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("detail", {
				data: IdView
			});
		},
		onDelete: function (oEvent) {
			var bindingContext = oEvent.getSource().getBindingContext("client");
			var selectedClient = bindingContext.getObject();
			this.IdView = selectedClient.id;

			var that = this;
			MessageBox.show("Tem certeza que deseja deletar esses dados?", {
				icon: MessageBox.Icon.WARNING,
				title: "Deletar Cliente",
				actions: [MessageBox.Action.YES, MessageBox.Action.NO],
				emphasizedAction: MessageBox.Action.YES,
				initialFocus: MessageBox.Action.NO,
				onClose: function (oAction) {
					if (oAction == "YES") {
						sap.ui.getCore().getElementById("oBusyDialog").open();
						that.onDeleteClient()
						
                    }
                }
            })
		},

		onDeleteClient: function () {
			var that = this;
			$.ajax({
				dataType: "json",
				type: "POST",
				url: "https://localhost:5001/api/Cliente/Delete",
				data: { id: this.IdView },
				success: function (response) {
					sap.ui.getCore().getElementById("oBusyDialog").close();
					MessageBox.show("Dados deletado com sucesso", {
						icon: MessageBox.Icon.SUCCESS,
						title: "Sucesso",
						actions: MessageBox.Action.OK,
						onClose: function (oAction) {
							if (oAction == "OK") {
								//var oModel = that.getView().getModel("client")
								//oModel.refresh(true)
								that._onObjectMatched()
							}
						}
					})
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(response)
					MessageBox.show("Erro ao deletar dados: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").close();
				}
			})
		},
	});
});