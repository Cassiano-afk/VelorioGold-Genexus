gx.evt.autoSkip=!1;gx.define("velorio",!1,function(){var t,n;this.ServerClass="velorio";this.PackageName="GeneXus.Programs";this.ServerFullClass="velorio.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="DesignGoldLegacy";this.SetStandaloneVars=function(){this.A56DataVelorio=gx.fn.getDateValue("DATAVELORIO");this.Gx_date=gx.fn.getDateValue("vTODAY");this.AV5IdCidade=gx.fn.getIntegerValue("vIDCIDADE",".")};this.e12182_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("webpanels.passwordvalidator.aspx",[],null,["SenhaAcesso"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e13182_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14182_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",6,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"velorio",[],!0,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","Novo registro",!1,!1,!1,null,null,!1,"",!0,[1,1,1,1],!1,0,!1,!1);n=this.Grid1Container;n.startDiv(7,"Grid1table","0px","0px");n.startDiv(8,"","0px","0px");n.startDiv(9,"","0px","0px");n.startDiv(10,"","0px","0px");n.addLabel();n.addSingleLineEdit(2,11,"NOME","","","Nome","svchar",50,"chr",50,50,"start",null,[],2,"Nome",!0,0,!1,!1,"small-text",0,"");n.endDiv();n.endDiv();n.endDiv();n.startDiv(12,"","0px","0px");n.startDiv(13,"","0px","0px");n.startDiv(14,"","0px","0px");n.addLabel();n.startDiv(15,"","0px","0px");n.addSingleLineEdit(57,16,"HORAINICIO","","","HoraInicio","dtime",5,"chr",5,5,"end",null,[],57,"HoraInicio",!0,5,!1,!1,"Attribute",0,"");n.endDiv();n.endDiv();n.endDiv();n.endDiv();n.startDiv(17,"","0px","0px");n.startDiv(18,"","0px","0px");n.startDiv(19,"","0px","0px");n.addLabel();n.startDiv(20,"","0px","0px");n.addSingleLineEdit(58,21,"HORAFIM","","","HoraFim","dtime",5,"chr",5,5,"end",null,[],58,"HoraFim",!0,5,!1,!1,"Attribute",0,"");n.endDiv();n.endDiv();n.endDiv();n.endDiv();n.startDiv(22,"","0px","0px");n.startDiv(23,"","0px","0px");n.addButton(24,"CHAMATRANSMISSAO","standard","'","e12182_client");n.endDiv();n.endDiv();n.endDiv();this.Grid1Container.emptyText="";this.setGrid(n);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[7]={id:7,fld:"GRID1TABLE",grid:6};t[8]={id:8,fld:"",grid:6};t[9]={id:9,fld:"",grid:6};t[10]={id:10,fld:"",grid:6};t[11]={id:11,lvl:2,type:"svchar",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:6,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOME",fmt:0,gxz:"Z2Nome",gxold:"O2Nome",gxvar:"A2Nome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2Nome=n)},v2z:function(n){n!==undefined&&(gx.O.Z2Nome=n)},v2c:function(n){gx.fn.setGridControlValue("NOME",n||gx.fn.currentGridRowImpl(6),gx.O.A2Nome,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2Nome=this.val(n))},val:function(n){return gx.fn.getGridControlValue("NOME",n||gx.fn.currentGridRowImpl(6))},nac:gx.falseFn};t[12]={id:12,fld:"",grid:6};t[13]={id:13,fld:"",grid:6};t[14]={id:14,fld:"",grid:6};t[15]={id:15,fld:"",grid:6};t[16]={id:16,lvl:2,type:"dtime",len:0,dec:5,sign:!1,ro:1,isacc:0,grid:6,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HORAINICIO",fmt:0,gxz:"Z57HoraInicio",gxold:"O57HoraInicio",gxvar:"A57HoraInicio",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A57HoraInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z57HoraInicio=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("HORAINICIO",n||gx.fn.currentGridRowImpl(6),gx.O.A57HoraInicio,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A57HoraInicio=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("HORAINICIO",n||gx.fn.currentGridRowImpl(6))},nac:gx.falseFn};t[17]={id:17,fld:"",grid:6};t[18]={id:18,fld:"",grid:6};t[19]={id:19,fld:"",grid:6};t[20]={id:20,fld:"",grid:6};t[21]={id:21,lvl:2,type:"dtime",len:0,dec:5,sign:!1,ro:1,isacc:0,grid:6,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"HORAFIM",fmt:0,gxz:"Z58HoraFim",gxold:"O58HoraFim",gxvar:"A58HoraFim",dp:{f:0,st:!0,wn:!1,mf:!1,pic:"99:99",dec:5},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A58HoraFim=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z58HoraFim=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("HORAFIM",n||gx.fn.currentGridRowImpl(6),gx.O.A58HoraFim,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A58HoraFim=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("HORAFIM",n||gx.fn.currentGridRowImpl(6))},nac:gx.falseFn};t[22]={id:22,fld:"",grid:6};t[23]={id:23,fld:"",grid:6};t[24]={id:24,fld:"CHAMATRANSMISSAO",grid:6,evt:"e12182_client"};this.Z2Nome="";this.O2Nome="";this.Z57HoraInicio=gx.date.nullDate();this.O57HoraInicio=gx.date.nullDate();this.Z58HoraFim=gx.date.nullDate();this.O58HoraFim=gx.date.nullDate();this.AV5IdCidade=0;this.A64IdCidade=0;this.A56DataVelorio=gx.date.nullDate();this.A2Nome="";this.A57HoraInicio=gx.date.nullDate();this.A58HoraFim=gx.date.nullDate();this.Gx_date=gx.date.nullDate();this.Events={e13182_client:["ENTER",!0],e14182_client:["CANCEL",!0],e12182_client:["'ACESSAR CERIMôNIA'",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"AV5IdCidade",fld:"vIDCIDADE",pic:"ZZZ9"},{av:"Gx_date",fld:"vTODAY",hsh:!0}],[]];this.EvtParms["'ACESSAR CERIMôNIA'"]=[[],[]];this.EvtParms["GRID1.LOAD"]=[[{av:"A57HoraInicio",fld:"HORAINICIO",pic:"99:99"},{av:"A58HoraFim",fld:"HORAFIM",pic:"99:99"},{av:"A56DataVelorio",fld:"DATAVELORIO"},{av:"Gx_date",fld:"vTODAY",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A56DataVelorio","DATAVELORIO",0,"date",8,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV5IdCidade","vIDCIDADE",0,"int",4,0);this.setVCMap("AV5IdCidade","vIDCIDADE",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("AV5IdCidade","vIDCIDADE",0,"int",4,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);n.addRefreshingVar({rfrVar:"AV5IdCidade"});n.addRefreshingVar({rfrVar:"Gx_date"});n.addRefreshingParm({rfrVar:"AV5IdCidade"});n.addRefreshingParm({rfrVar:"Gx_date"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.velorio)})