gx.evt.autoSkip=!1;gx.define("webpanels.buscavelorio",!1,function(){this.ServerClass="webpanels.buscavelorio";this.PackageName="GeneXus.Programs";this.ServerFullClass="webpanels.buscavelorio.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="DesignGoldLegacy";this.SetStandaloneVars=function(){this.AV7AoVivo=gx.fn.getControlValue("vAOVIVO")};this.Validv_Idestado=function(){return this.validSrvEvt("Validv_Idestado",0).then(function(n){return n}.closure(this))};this.e110l1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.popupOpenUrl(gx.http.formatLink("webpanels.velorioteste.aspx",[this.AV6IdCidade]),[]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e130l1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.call("webpanels.transmissao.aspx",[],null,["AoVivo"]);this.refreshOutputs([]);this.OnClientEventEnd()},arguments)};this.e140l2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e150l2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52];this.GXLastCtrlId=52;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLE2",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TEXTBLOCK1",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"IMAGE1",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"TABLE1",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"TABLE3",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"TABLE5",grid:0};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"TABLE8",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"TEXTBLOCK2",format:0,grid:0,ctrltype:"textblock"};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Idestado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIDESTADO",fmt:0,gxz:"ZV5IdEstado",gxold:"OV5IdEstado",gxvar:"AV5IdEstado",ucs:[],op:[45],ip:[45,31],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV5IdEstado=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5IdEstado=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vIDESTADO",gx.O.AV5IdEstado)},c2v:function(){this.val()!==undefined&&(gx.O.AV5IdEstado=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vIDESTADO",".")},nac:gx.falseFn};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"TABLE6",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"TABLE7",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"TEXTBLOCK3",format:0,grid:0,ctrltype:"textblock"};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vIDCIDADE",fmt:0,gxz:"ZV6IdCidade",gxold:"OV6IdCidade",gxvar:"AV6IdCidade",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV6IdCidade=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6IdCidade=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vIDCIDADE",gx.O.AV6IdCidade)},c2v:function(){this.val()!==undefined&&(gx.O.AV6IdCidade=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vIDCIDADE",".")},nac:gx.falseFn};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TABLE4",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BUSCARCERIMONIA",grid:0,evt:"e110l1_client"};n[52]={id:52,fld:"",grid:0};this.AV5IdEstado=0;this.ZV5IdEstado=0;this.OV5IdEstado=0;this.AV6IdCidade=0;this.ZV6IdCidade=0;this.OV6IdCidade=0;this.AV5IdEstado=0;this.AV6IdCidade=0;this.AV7AoVivo=!1;this.Events={e140l2_client:["ENTER",!0],e150l2_client:["CANCEL",!0],e110l1_client:["'BUSCAR CERIMONIA'",!1],e130l1_client:["GLOBALEVENTS.ABRIRTELA",!1]};this.EvtParms.REFRESH=[[{ctrl:"vIDESTADO"},{av:"AV5IdEstado",fld:"vIDESTADO",pic:"ZZZ9"}],[]];this.EvtParms["'BUSCAR CERIMONIA'"]=[[{ctrl:"vIDCIDADE"},{av:"AV6IdCidade",fld:"vIDCIDADE",pic:"ZZZ9"}],[]];this.EvtParms["GLOBALEVENTS.ABRIRTELA"]=[[],[]];this.addExoEventHandler("AbrirTela",this.e130l1_client);this.EvtParms.ENTER=[[],[]];this.EvtParms.VALIDV_IDESTADO=[[{ctrl:"vIDESTADO"},{av:"AV5IdEstado",fld:"vIDESTADO",pic:"ZZZ9"},{ctrl:"vIDCIDADE"},{av:"AV6IdCidade",fld:"vIDCIDADE",pic:"ZZZ9"}],[{ctrl:"vIDCIDADE"},{av:"AV6IdCidade",fld:"vIDCIDADE",pic:"ZZZ9"}]];this.setVCMap("AV7AoVivo","vAOVIVO",0,"boolean",4,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.webpanels.buscavelorio)})