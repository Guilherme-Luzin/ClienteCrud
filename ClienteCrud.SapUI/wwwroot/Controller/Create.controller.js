sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"
], function (Controller, History, JSONModel, MessageBox) {
	"use strict";
	return Controller.extend("sap.ui.crudCliente.Controller.Create", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("edit").attachPatternMatched(this._onObjectMatched, this);
		},
		onBeforeRendering: function () {
			sap.ui.getCore().getElementById("oBusyDialog").open();
		},

		onAfterRendering: function () {
			sap.ui.getCore().getElementById("oBusyDialog").close();
		},

		_onObjectMatched: function (oEvent) {
			sap.ui.getCore().getElementById("oBusyDialog").open();
			var Id = oEvent.getParameter("arguments").data
			var that = this;
			$.ajax({
				dataType: "json",
				type: "GET",
				data: { id: Id },
				url: "https://localhost:5001/api/Cliente/GetClient",
				success: function (response) {
					var oViewModel = new JSONModel(response)
					that.getView().setModel(oViewModel, "client")
					sap.ui.getCore().getElementById("oBusyDialog").close();
				},
				error: function (response) {
					var ConvertedResponse = JSON.stringify(response)
					console.table(ConvertedResponse)
					MessageBox.show("Erro ao carregar dados: " + ConvertedResponse, {
						icon: MessageBox.Icon.ERROR,
						title: "Erro"
					})
					sap.ui.getCore().getElementById("oBusyDialog").close();
 				}
			})
		},

		onNavBack: function () {
			var oHistory = History.getInstance();
			var sPreviousHash = oHistory.getPreviousHash();
			if (sPreviousHash !== undefined) {
				window.history.go(-1);
			} else {
				var oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("overview", {}, true);
			}
			this.getView().byId("inId").setValue(null);
			this.getView().byId("inNome").setValue(null);
			this.getView().byId("inEmail").setValue(null);
			this.getView().byId("inIdade").setValue(null);

			this.getView().byId("inNome").setValueState(sap.ui.core.ValueState.None);
			this.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.None);
			this.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.None);
		},
		onAddClient: function (oEvent) {
			var id = this.getView().byId("inId").getValue();
			var nome = this.getView().byId("inNome").getValue();
			var email = this.getView().byId("inEmail").getValue();
			var idade = this.getView().byId("inIdade").getValue();

			var mailregex = /^\w+[\w-+\.]*\@\w+([-\.]\w+)*\.[a-zA-Z]{2,}$/;
			var validaNome = /[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$/

			if (nome == "" || !validaNome.test(nome)) {
				MessageBox.show("O nome não pode ficar em branco e NÃO deve conter números", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
                })
				this.getView().byId("inNome").setValueState(sap.ui.core.ValueState.Error);
			}
			else if (email == "" || !mailregex.test(email)) {
				MessageBox.show("Insira um e-mail válido! \nexemplo@exemplo.exemplo", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
                })
				this.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.Error);
			}
			else if (idade == "" || idade <= 0 || idade > 122) {
				MessageBox.show("Insira uma idade válida", {
					icon: MessageBox.Icon.ERROR,
					title: "Erro"
				})
				this.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.Error);
			}
			else {
				sap.ui.getCore().getElementById("oBusyDialog").open();
				var cliente = {
					Id: id,
					Nome: nome,
					Email: email,
					Idade: idade
				}	
				var that = this;
				var oRouter = that.getOwnerComponent().getRouter();
				$.ajax({
					dataType: "json",
					type: "POST",
					url: "https://localhost:5001/api/Cliente/Create",
					data: { cliente: cliente },
					success: function (response) {
						MessageBox.show("Dados salvos com sucesso", {
							icon: MessageBox.Icon.SUCCESS,
							title: "Sucesso",
							actions: MessageBox.Action.OK,
							onClose: function (oAction) {
								if (oAction == "OK") {
									oRouter.navTo("overview", {}, true)

									that.getView().byId("inId").setValue(null);
									that.getView().byId("inNome").setValue(null);
									that.getView().byId("inEmail").setValue(null);
									that.getView().byId("inIdade").setValue(null);

									that.getView().byId("inNome").setValueState(sap.ui.core.ValueState.None);
									that.getView().byId("inEmail").setValueState(sap.ui.core.ValueState.None);
									that.getView().byId("inIdade").setValueState(sap.ui.core.ValueState.None);
								}
							}
						})
						sap.ui.getCore().getElementById("oBusyDialog").close();
					},
					error: function (response) {
						var ConvertedResponse = JSON.stringify(response)
						MessageBox.show("Erro ao salvar dados: " + ConvertedResponse, {
							icon: MessageBox.Icon.ERROR,
							title: "erro"
						})
						sap.ui.getCore().getElementById("oBusyDialog").close();
					}
				})
			}
		}
	});
});
