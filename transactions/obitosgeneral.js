gx.evt.autoSkip=!1;gx.define("transactions.obitosgeneral",!0,function(n){this.ServerClass="transactions.obitosgeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="transactions.obitosgeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="DesignGoldLegacy";this.SetStandaloneVars=function(){};this.Valid_Inscricao=function(){return this.validCliEvt("Valid_Inscricao",0,function(){try{var n=gx.util.balloon.getNew("INSCRICAO");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Nome=function(){return this.validCliEvt("Valid_Nome",0,function(){try{var n=gx.util.balloon.getNew("NOME");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11051_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("transactions.obitos.aspx",["UPD",this.A1Inscricao,this.A2Nome],null,["Mode","Inscricao","Nome"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e12051_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("transactions.obitos.aspx",["DLT",this.A1Inscricao,this.A2Nome],null,["Mode","Inscricao","Nome"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e15052_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16052_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11051_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12051_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:9,dec:0,sign:!1,pic:"ZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Inscricao,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INSCRICAO",fmt:0,gxz:"Z1Inscricao",gxold:"O1Inscricao",gxvar:"A1Inscricao",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1Inscricao=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1Inscricao=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("INSCRICAO",gx.O.A1Inscricao,0)},c2v:function(){this.val()!==undefined&&(gx.O.A1Inscricao=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("INSCRICAO",".")},nac:gx.falseFn};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Nome,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NOME",fmt:0,gxz:"Z2Nome",gxold:"O2Nome",gxvar:"A2Nome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2Nome=n)},v2z:function(n){n!==undefined&&(gx.O.Z2Nome=n)},v2c:function(){gx.fn.setControlValue("NOME",gx.O.A2Nome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A2Nome=this.val())},val:function(){return gx.fn.getControlValue("NOME")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"NASCIMENTO",fmt:0,gxz:"Z8Nascimento",gxold:"O8Nascimento",gxvar:"A8Nascimento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8Nascimento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z8Nascimento=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("NASCIMENTO",gx.O.A8Nascimento,0)},c2v:function(){this.val()!==undefined&&(gx.O.A8Nascimento=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("NASCIMENTO")},nac:gx.falseFn};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FALECIMENTO",fmt:0,gxz:"Z9Falecimento",gxold:"O9Falecimento",gxvar:"A9Falecimento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9Falecimento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z9Falecimento=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("FALECIMENTO",gx.O.A9Falecimento,0)},c2v:function(){this.val()!==undefined&&(gx.O.A9Falecimento=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("FALECIMENTO")},nac:gx.falseFn};this.A1Inscricao=0;this.Z1Inscricao=0;this.O1Inscricao=0;this.A2Nome="";this.Z2Nome="";this.O2Nome="";this.A8Nascimento=gx.date.nullDate();this.Z8Nascimento=gx.date.nullDate();this.O8Nascimento=gx.date.nullDate();this.A9Falecimento=gx.date.nullDate();this.Z9Falecimento=gx.date.nullDate();this.O9Falecimento=gx.date.nullDate();this.A1Inscricao=0;this.A2Nome="";this.A8Nascimento=gx.date.nullDate();this.A9Falecimento=gx.date.nullDate();this.Events={e15052_client:["ENTER",!0],e16052_client:["CANCEL",!0],e11051_client:["'DOUPDATE'",!1],e12051_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A1Inscricao",fld:"INSCRICAO",pic:"ZZZZZZZZ9"},{av:"A2Nome",fld:"NOME"}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A1Inscricao",fld:"INSCRICAO",pic:"ZZZZZZZZ9"},{av:"A2Nome",fld:"NOME"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A1Inscricao",fld:"INSCRICAO",pic:"ZZZZZZZZ9"},{av:"A2Nome",fld:"NOME"}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_INSCRICAO=[[],[]];this.EvtParms.VALID_NOME=[[],[]];this.Initialize()})