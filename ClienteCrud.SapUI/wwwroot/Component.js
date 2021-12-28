sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/resource/ResourceModel"
 ], function (UIComponent, ResourceModel) {
    "use strict";
    return UIComponent.extend("sap.ui.crudCliente.Component", {
        metadata: {
            manifest: "json"
        },
       init: function () {
            // call the init function of the parent
           UIComponent.prototype.init.apply(this, arguments);
            // set i18n model
            var i18nModel = new ResourceModel({
                bundleName: "sap.ui.crudCliente.i18n.i18n"
            });
            this.setModel(i18nModel, "i18n");
            this.getRouter().initialize();
       }
    });
 });
 