gx.evt.autoSkip=!1;gx.define("gamexampleupdateregisteruser",!1,function(){this.ServerClass="gamexampleupdateregisteruser";this.PackageName="GeneXus.Programs";this.ServerFullClass="gamexampleupdateregisteruser.aspx";this.setObjectType("web");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="DesignGoldLegacy";this.SetStandaloneVars=function(){this.AV18IDP_State=gx.fn.getControlValue("vIDP_STATE")};this.Validv_Birthday=function(){return this.validCliEvt("Validv_Birthday",0,function(){try{var n=gx.util.balloon.getNew("vBIRTHDAY");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV6Birthday)===0||new gx.date.gxdate(this.AV6Birthday).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Birthday fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Gender=function(){return this.validCliEvt("Validv_Gender",0,function(){try{var n=gx.util.balloon.getNew("vGENDER");if(this.AnyError=0,!(gx.text.compare(this.AV17Gender,"N")==0||gx.text.compare(this.AV17Gender,"F")==0||gx.text.compare(this.AV17Gender,"M")==0))try{n.setError("Campo Gender fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e120x2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e130x2_client=function(){return this.executeServerEvent("'RETURNTOLOGIN'",!1,null,!1,!1)};this.e150x2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,80,81,82,83,84,85,86];this.GXLastCtrlId=86;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TBTITLE",format:0,grid:0,ctrltype:"textblock"};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,lvl:0,type:"svchar",len:100,dec:60,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNAME",fmt:0,gxz:"ZV22Name",gxold:"OV22Name",gxvar:"AV22Name",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV22Name=n)},v2z:function(n){n!==undefined&&(gx.O.ZV22Name=n)},v2c:function(){gx.fn.setControlValue("vNAME",gx.O.AV22Name,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV22Name=this.val())},val:function(){return gx.fn.getControlValue("vNAME")},nac:gx.falseFn};this.declareDomainHdlr(11,function(){});n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vEMAIL",fmt:0,gxz:"ZV8EMail",gxold:"OV8EMail",gxvar:"AV8EMail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8EMail=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8EMail=n)},v2c:function(){gx.fn.setControlValue("vEMAIL",gx.O.AV8EMail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV8EMail=this.val())},val:function(){return gx.fn.getControlValue("vEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(16,function(){});n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"CELL_FIRSTNAME",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vFIRSTNAME",fmt:0,gxz:"ZV9FirstName",gxold:"OV9FirstName",gxvar:"AV9FirstName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9FirstName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV9FirstName=n)},v2c:function(){gx.fn.setControlValue("vFIRSTNAME",gx.O.AV9FirstName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV9FirstName=this.val())},val:function(){return gx.fn.getControlValue("vFIRSTNAME")},nac:gx.falseFn};this.declareDomainHdlr(21,function(){});n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"CELL_LASTNAME",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLASTNAME",fmt:0,gxz:"ZV21LastName",gxold:"OV21LastName",gxvar:"AV21LastName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV21LastName=n)},v2z:function(n){n!==undefined&&(gx.O.ZV21LastName=n)},v2c:function(){gx.fn.setControlValue("vLASTNAME",gx.O.AV21LastName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV21LastName=this.val())},val:function(){return gx.fn.getControlValue("vLASTNAME")},nac:gx.falseFn};this.declareDomainHdlr(26,function(){});n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"CELL_PHONE",grid:0};n[29]={id:29,fld:"",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPHONE",fmt:0,gxz:"ZV23Phone",gxold:"OV23Phone",gxvar:"AV23Phone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV23Phone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV23Phone=n)},v2c:function(){gx.fn.setControlValue("vPHONE",gx.O.AV23Phone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV23Phone=this.val())},val:function(){return gx.fn.getControlValue("vPHONE")},nac:gx.falseFn};this.declareDomainHdlr(31,function(){});n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"CELL_BIRTHDAY",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Birthday,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vBIRTHDAY",fmt:0,gxz:"ZV6Birthday",gxold:"OV6Birthday",gxvar:"AV6Birthday",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6Birthday=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6Birthday=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vBIRTHDAY",gx.O.AV6Birthday,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV6Birthday=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vBIRTHDAY")},nac:gx.falseFn};this.declareDomainHdlr(36,function(){});n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"CELL_GENDER",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,lvl:0,type:"char",len:1,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Gender,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vGENDER",fmt:0,gxz:"ZV17Gender",gxold:"OV17Gender",gxvar:"AV17Gender",ucs:[],op:[41],ip:[41],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV17Gender=n)},v2z:function(n){n!==undefined&&(gx.O.ZV17Gender=n)},v2c:function(){gx.fn.setComboBoxValue("vGENDER",gx.O.AV17Gender);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV17Gender=this.val())},val:function(){return gx.fn.getControlValue("vGENDER")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"CELL_ADDRESS",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vADDRESS",fmt:0,gxz:"ZV5Address",gxold:"OV5Address",gxvar:"AV5Address",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV5Address=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5Address=n)},v2c:function(){gx.fn.setControlValue("vADDRESS",gx.O.AV5Address,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV5Address=this.val())},val:function(){return gx.fn.getControlValue("vADDRESS")},nac:gx.falseFn};this.declareDomainHdlr(46,function(){});n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"CELL_CITY",grid:0};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vCITY",fmt:0,gxz:"ZV7City",gxold:"OV7City",gxvar:"AV7City",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7City=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7City=n)},v2c:function(){gx.fn.setControlValue("vCITY",gx.O.AV7City,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV7City=this.val())},val:function(){return gx.fn.getControlValue("vCITY")},nac:gx.falseFn};this.declareDomainHdlr(51,function(){});n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"CELL_STATE",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"char",len:254,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vSTATE",fmt:0,gxz:"ZV25State",gxold:"OV25State",gxvar:"AV25State",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV25State=n)},v2z:function(n){n!==undefined&&(gx.O.ZV25State=n)},v2c:function(){gx.fn.setControlValue("vSTATE",gx.O.AV25State,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV25State=this.val())},val:function(){return gx.fn.getControlValue("vSTATE")},nac:gx.falseFn};this.declareDomainHdlr(56,function(){});n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"CELL_POSTCODE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vPOSTCODE",fmt:0,gxz:"ZV24PostCode",gxold:"OV24PostCode",gxvar:"AV24PostCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV24PostCode=n)},v2z:function(n){n!==undefined&&(gx.O.ZV24PostCode=n)},v2c:function(){gx.fn.setControlValue("vPOSTCODE",gx.O.AV24PostCode,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV24PostCode=this.val())},val:function(){return gx.fn.getControlValue("vPOSTCODE")},nac:gx.falseFn};this.declareDomainHdlr(61,function(){});n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"CELL_LANGUAGE",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"svchar",len:15,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLANGUAGE",fmt:0,gxz:"ZV20Language",gxold:"OV20Language",gxvar:"AV20Language",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV20Language=n)},v2z:function(n){n!==undefined&&(gx.O.ZV20Language=n)},v2c:function(){gx.fn.setComboBoxValue("vLANGUAGE",gx.O.AV20Language);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV20Language=this.val())},val:function(){return gx.fn.getControlValue("vLANGUAGE")},nac:gx.falseFn};this.declareDomainHdlr(66,function(){});n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"CELL_TIMEZONE",grid:0};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTIMEZONE",fmt:0,gxz:"ZV26Timezone",gxold:"OV26Timezone",gxvar:"AV26Timezone",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV26Timezone=n)},v2z:function(n){n!==undefined&&(gx.O.ZV26Timezone=n)},v2c:function(){gx.fn.setControlValue("vTIMEZONE",gx.O.AV26Timezone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV26Timezone=this.val())},val:function(){return gx.fn.getControlValue("vTIMEZONE")},nac:gx.falseFn};this.declareDomainHdlr(71,function(){});n[72]={id:72,fld:"",grid:0};n[73]={id:73,fld:"CELL_PHOTO",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"svchar",len:2048,dec:250,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vURLIMAGE",fmt:0,gxz:"ZV28URLImage",gxold:"OV28URLImage",gxvar:"AV28URLImage",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV28URLImage=n)},v2z:function(n){n!==undefined&&(gx.O.ZV28URLImage=n)},v2c:function(){gx.fn.setControlValue("vURLIMAGE",gx.O.AV28URLImage,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.AV28URLImage=this.val())},val:function(){return gx.fn.getControlValue("vURLIMAGE")},nac:gx.falseFn};this.declareDomainHdlr(76,function(){});n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"",grid:0};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[84]={id:84,fld:"BUTTONLOGIN",grid:0,evt:"e130x2_client"};n[85]={id:85,fld:"",grid:0};n[86]={id:86,fld:"BUTTON2",grid:0,evt:"e120x2_client",std:"ENTER"};this.AV22Name="";this.ZV22Name="";this.OV22Name="";this.AV8EMail="";this.ZV8EMail="";this.OV8EMail="";this.AV9FirstName="";this.ZV9FirstName="";this.OV9FirstName="";this.AV21LastName="";this.ZV21LastName="";this.OV21LastName="";this.AV23Phone="";this.ZV23Phone="";this.OV23Phone="";this.AV6Birthday=gx.date.nullDate();this.ZV6Birthday=gx.date.nullDate();this.OV6Birthday=gx.date.nullDate();this.AV17Gender="";this.ZV17Gender="";this.OV17Gender="";this.AV5Address="";this.ZV5Address="";this.OV5Address="";this.AV7City="";this.ZV7City="";this.OV7City="";this.AV25State="";this.ZV25State="";this.OV25State="";this.AV24PostCode="";this.ZV24PostCode="";this.OV24PostCode="";this.AV20Language="";this.ZV20Language="";this.OV20Language="";this.AV26Timezone="";this.ZV26Timezone="";this.OV26Timezone="";this.AV28URLImage="";this.ZV28URLImage="";this.OV28URLImage="";this.AV22Name="";this.AV8EMail="";this.AV9FirstName="";this.AV21LastName="";this.AV23Phone="";this.AV6Birthday=gx.date.nullDate();this.AV17Gender="";this.AV5Address="";this.AV7City="";this.AV25State="";this.AV24PostCode="";this.AV20Language="";this.AV26Timezone="";this.AV28URLImage="";this.AV18IDP_State="";this.Events={e120x2_client:["ENTER",!0],e130x2_client:["'RETURNTOLOGIN'",!0],e150x2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"AV18IDP_State",fld:"vIDP_STATE",hsh:!0}],[]];this.EvtParms.ENTER=[[{av:"AV22Name",fld:"vNAME"},{av:"AV8EMail",fld:"vEMAIL"},{av:"AV9FirstName",fld:"vFIRSTNAME"},{av:"AV21LastName",fld:"vLASTNAME"},{av:"AV23Phone",fld:"vPHONE"},{av:"AV6Birthday",fld:"vBIRTHDAY"},{ctrl:"vGENDER"},{av:"AV17Gender",fld:"vGENDER"},{av:"AV5Address",fld:"vADDRESS"},{av:"AV7City",fld:"vCITY"},{av:"AV25State",fld:"vSTATE"},{av:"AV24PostCode",fld:"vPOSTCODE"},{ctrl:"vLANGUAGE"},{av:"AV20Language",fld:"vLANGUAGE"},{av:"AV26Timezone",fld:"vTIMEZONE"},{av:"AV28URLImage",fld:"vURLIMAGE"},{av:"AV18IDP_State",fld:"vIDP_STATE",hsh:!0}],[]];this.EvtParms["'RETURNTOLOGIN'"]=[[],[]];this.EvtParms.VALIDV_BIRTHDAY=[[],[]];this.EvtParms.VALIDV_GENDER=[[],[]];this.EnterCtrl=["BUTTON2"];this.setVCMap("AV18IDP_State","vIDP_STATE",0,"char",60,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gamexampleupdateregisteruser)})