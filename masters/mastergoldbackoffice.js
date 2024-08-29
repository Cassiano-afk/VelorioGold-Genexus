gx.evt.autoSkip = false;
gx.define('masters.mastergoldbackoffice', false, function () {
   this.ServerClass =  "masters.mastergoldbackoffice" ;
   this.PackageName =  "GeneXus.Programs" ;
   this.ServerFullClass =  "masters.mastergoldbackoffice.aspx" ;
   this.setObjectType("web");
   this.IsMasterPage=true;
   this.hasEnterEvent = false;
   this.skipOnEnter = false;
   this.autoRefresh = true;
   this.fullAjax = true;
   this.supportAjaxEvents =  true ;
   this.ajaxSecurityToken =  true ;
   this.DSO =  "Design\GoldLegacy" ;
   this.SetStandaloneVars=function()
   {
   };
   this.e120q1_client=function()
   {
      return this.executeClientEvent(  function() {
         this.clearMessages();
         if ( this.SIDEBARMENU_MPAGEContainer.isCollapsed )
         {
            gx.fn.setCtrlProperty("CONTENTWW_MPAGE","Class", "expandible-container-WW"+" expanded-WW" );
         }
         else
         {
            gx.fn.setCtrlProperty("CONTENTWW_MPAGE","Class", "expandible-container-WW" );
         }
         this.refreshOutputs([{"av":"gx.fn.getCtrlProperty(\u0027CONTENTWW_MPAGE\u0027,\u0027Class\u0027)","ctrl":"CONTENTWW_MPAGE","prop":"Class"}]);
         this.OnClientEventEnd();
      }, arguments);
   };
   this.e130q2_client=function()
   {
      return this.executeServerEvent("ENTER_MPAGE", true, null, false, false);
   };
   this.e140q2_client=function()
   {
      return this.executeServerEvent("CANCEL_MPAGE", true, null, false, false);
   };
   this.GXValidFnc = [];
   var GXValidFnc = this.GXValidFnc ;
   this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,17,18,19,20];
   this.GXLastCtrlId =20;
   this.SIDEBARMENU_MPAGEContainer = gx.uc.getNew(this, 16, 0, "GeneXusUnanimo_Sidebar", "SIDEBARMENU_MPAGEContainer", "Sidebarmenu", "SIDEBARMENU_MPAGE");
   var SIDEBARMENU_MPAGEContainer = this.SIDEBARMENU_MPAGEContainer;
   SIDEBARMENU_MPAGEContainer.setProp("Enabled", "Enabled", true, "boolean");
   SIDEBARMENU_MPAGEContainer.setDynProp("Title", "Title", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("Class", "Class", "ch-sidebar", "str");
   SIDEBARMENU_MPAGEContainer.setProp("FooterText", "Footertext", "", "str");
   SIDEBARMENU_MPAGEContainer.setDynProp("DistanceToTop", "Distancetotop", 0, "num");
   SIDEBARMENU_MPAGEContainer.setProp("Collapsible", "Collapsible", true, "bool");
   SIDEBARMENU_MPAGEContainer.addV2CFunction('AV8[var:5]', "v[VAR:5]_MPAGE", 'setSidebarItems');
   SIDEBARMENU_MPAGEContainer.addC2VFunction(function(UC) { UC.ParentObject.AV8[var:5]=UC.getSidebarItems();gx.fn.setControlValue("v[VAR:5]_MPAGE",UC.ParentObject.AV8[var:5]); });
   SIDEBARMENU_MPAGEContainer.setProp("SidebarItemsCurrentIndex", "Sidebaritemscurrentindex", 0, "num");
   SIDEBARMENU_MPAGEContainer.setProp("ActiveItemId", "Activeitemid", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("SelectedItemTarget", "Selecteditemtarget", "", "str");
   SIDEBARMENU_MPAGEContainer.setProp("isCollapsed", "Iscollapsed", false, "bool");
   SIDEBARMENU_MPAGEContainer.setProp("IconAutoColor", "Iconautocolor", false, "bool");
   SIDEBARMENU_MPAGEContainer.setProp("Visible", "Visible", true, "bool");
   SIDEBARMENU_MPAGEContainer.setProp("Gx Control Type", "Gxcontroltype", '', "int");
   SIDEBARMENU_MPAGEContainer.setC2ShowFunction(function(UC) { UC.show(); });
   SIDEBARMENU_MPAGEContainer.addEventHandler("GetState", this.e120q1_client);
   this.setUserControl(SIDEBARMENU_MPAGEContainer);
   GXValidFnc[2]={ id: 2, fld:"",grid:0};
   GXValidFnc[3]={ id: 3, fld:"MAINTABLE",grid:0};
   GXValidFnc[4]={ id: 4, fld:"",grid:0};
   GXValidFnc[5]={ id: 5, fld:"",grid:0};
   GXValidFnc[6]={ id: 6, fld:"TABLE2",grid:0};
   GXValidFnc[7]={ id: 7, fld:"",grid:0};
   GXValidFnc[8]={ id: 8, fld:"IMAGE4",grid:0};
   GXValidFnc[9]={ id: 9, fld:"",grid:0};
   GXValidFnc[10]={ id: 10, fld:"TEXTBLOCK1", format:0,grid:0, ctrltype: "textblock"};
   GXValidFnc[11]={ id: 11, fld:"",grid:0};
   GXValidFnc[12]={ id: 12, fld:"",grid:0};
   GXValidFnc[13]={ id: 13, fld:"TABLESIDEBARCONTAINER",grid:0};
   GXValidFnc[14]={ id: 14, fld:"",grid:0};
   GXValidFnc[15]={ id: 15, fld:"",grid:0};
   GXValidFnc[17]={ id: 17, fld:"",grid:0};
   GXValidFnc[18]={ id: 18, fld:"CONTENTWW",grid:0};
   GXValidFnc[19]={ id: 19, fld:"",grid:0};
   GXValidFnc[20]={ id: 20, fld:"",grid:0};
   this.AV8[var:5] = 0 ;
   this.Events = {"e130q2_client": ["ENTER_MPAGE", true] ,"e140q2_client": ["CANCEL_MPAGE", true] ,"e120q1_client": ["SIDEBARMENU_MPAGE.GETSTATE_MPAGE", false]};
   this.EvtParms["REFRESH_MPAGE"] = [[],[]];
   this.EvtParms["SIDEBARMENU_MPAGE.GETSTATE_MPAGE"] = [[{"av":"this.SIDEBARMENU_MPAGEContainer.isCollapsed","ctrl":"SIDEBARMENU_MPAGE","prop":"isCollapsed"}],[{"av":"gx.fn.getCtrlProperty(\u0027CONTENTWW_MPAGE\u0027,\u0027Class\u0027)","ctrl":"CONTENTWW_MPAGE","prop":"Class"}]];
   this.EvtParms["ENTER_MPAGE"] = [[],[]];
   this.Initialize( );
});
gx.wi( function() { gx.createMasterPage(masters.mastergoldbackoffice);});
