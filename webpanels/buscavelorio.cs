using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.webpanels {
   public class buscavelorio : GXHttpHandler
   {
      public buscavelorio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public buscavelorio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( bool aP0_AoVivo )
      {
         this.AV7AoVivo = aP0_AoVivo;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavIdestado = new GXCombobox();
         dynavIdcidade = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AoVivo");
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vIDCIDADE") == 0 )
            {
               AV5IdEstado = (short)(Math.Round(NumberUtil.Val( GetPar( "IdEstado"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvIDCIDADE0L2( AV5IdEstado) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AoVivo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AoVivo");
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV7AoVivo = StringUtil.StrToBool( gxfirstwebparm);
               AssignAttri("", false, "AV7AoVivo", AV7AoVivo);
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            ValidateSpaRequest();
            PA0L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS0L2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0L2( ) ;
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Assista a um velório online | Velório Gold") ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1318140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("webpanels.buscavelorio.aspx", new object[] {UrlEncode(StringUtil.BoolToStr(AV7AoVivo))}, new string[] {"AoVivo"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vAOVIVO", AV7AoVivo);
      }

      protected void RenderHtmlCloseForm0L2( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WebPanels.BuscaVelorio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assista a um velório online | Velório Gold" ;
      }

      protected void WB0L0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:150px auto auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Assista a um velório online.", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Titulo1", 0, "", 1, 1, 0, 0, "HLP_WebPanels/BuscaVelorio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgImage1_gximage, "")==0) ? "GX_Image_Design_LinhaH_Class" : "GX_Image_"+imgImage1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "d2f8511e-1dd1-4704-8c8e-d6de65ae8662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 300, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WebPanels/BuscaVelorio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:80px auto 70px auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:14fr 42fr 0fr 6fr 38fr 0fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:27fr 46fr 27fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Estado", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "small-text", 0, "", 1, 1, 0, 0, "HLP_WebPanels/BuscaVelorio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavIdestado_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavIdestado, dynavIdestado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0)), 1, dynavIdestado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavIdestado.Enabled, 0, 0, 0, "em", 0, "", "", "custom-dropdown", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_WebPanels/BuscaVelorio.htm");
            dynavIdestado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0));
            AssignProp("", false, dynavIdestado_Internalname, "Values", (string)(dynavIdestado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:6fr 16fr 78fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cidade", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "small-text", 0, "", 1, 1, 0, 0, "HLP_WebPanels/BuscaVelorio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+dynavIdcidade_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavIdcidade, dynavIdcidade_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0)), 1, dynavIdcidade_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavIdcidade.Enabled, 0, 0, 0, "em", 0, "", "", "custom-dropdown", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_WebPanels/BuscaVelorio.htm");
            dynavIdcidade.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0));
            AssignProp("", false, dynavIdcidade_Internalname, "Values", (string)(dynavIdcidade.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 100, "%", 0, "px", "Table", "start", "top", " "+"data-gx-smarttable"+" ", "grid-template-columns:100fr;grid-template-rows:auto;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", " "+"data-gx-smarttable-cell"+" ", "display:flex;justify-content:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "ButtonAcessoVelorio";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBuscarcerimonia_Internalname, "", "Buscar Cerimonia", bttBuscarcerimonia_Jsonclick, 7, "Buscar Cerimonia", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110l1_client"+"'", TempTags, "", 2, "HLP_WebPanels/BuscaVelorio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0L2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Assista a um velório online | Velório Gold", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0L0( ) ;
      }

      protected void WS0L2( )
      {
         START0L2( ) ;
         EVT0L2( ) ;
      }

      protected void EVT0L2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E120L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0L2( ) ;
            }
         }
      }

      protected void PA0L2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavIdestado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvIDCIDADE_html0L2( AV5IdEstado) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvIDESTADO0L1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvIDESTADO_data0L1( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvIDESTADO_html0L1( )
      {
         short gxdynajaxvalue;
         GXDLVvIDESTADO_data0L1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavIdestado.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavIdestado.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavIdestado.ItemCount > 0 )
         {
            AV5IdEstado = (short)(Math.Round(NumberUtil.Val( dynavIdestado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
         }
      }

      protected void GXDLVvIDESTADO_data0L1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000L2_A61IdEstado[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000L2_A62NomeEstado[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvIDCIDADE0L2( short AV5IdEstado )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvIDCIDADE_data0L2( AV5IdEstado) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvIDCIDADE_html0L2( short AV5IdEstado )
      {
         short gxdynajaxvalue;
         GXDLVvIDCIDADE_data0L2( AV5IdEstado) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavIdcidade.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavIdcidade.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavIdcidade.ItemCount > 0 )
         {
            AV6IdCidade = (short)(Math.Round(NumberUtil.Val( dynavIdcidade.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6IdCidade", StringUtil.LTrimStr( (decimal)(AV6IdCidade), 4, 0));
         }
      }

      protected void GXDLVvIDCIDADE_data0L2( short AV5IdEstado )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H000L3 */
         pr_default.execute(1, new Object[] {AV5IdEstado});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000L3_A64IdCidade[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000L3_A65NomeCidade[0]));
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavIdestado.Name = "vIDESTADO";
            dynavIdestado.WebTags = "";
            dynavIdestado.removeAllItems();
            /* Using cursor H000L4 */
            pr_default.execute(2);
            while ( (pr_default.getStatus(2) != 101) )
            {
               dynavIdestado.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000L4_A61IdEstado[0]), 4, 0)), H000L4_A62NomeEstado[0], 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            if ( dynavIdestado.ItemCount > 0 )
            {
               AV5IdEstado = (short)(Math.Round(NumberUtil.Val( dynavIdestado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavIdestado.ItemCount > 0 )
         {
            AV5IdEstado = (short)(Math.Round(NumberUtil.Val( dynavIdestado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavIdestado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0));
            AssignProp("", false, dynavIdestado_Internalname, "Values", dynavIdestado.ToJavascriptSource(), true);
         }
         if ( dynavIdcidade.ItemCount > 0 )
         {
            AV6IdCidade = (short)(Math.Round(NumberUtil.Val( dynavIdcidade.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6IdCidade", StringUtil.LTrimStr( (decimal)(AV6IdCidade), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavIdcidade.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0));
            AssignProp("", false, dynavIdcidade_Internalname, "Values", dynavIdcidade.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E120L2 ();
            WB0L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0L2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavIdestado.CurrentValue = cgiGet( dynavIdestado_Internalname);
            AV5IdEstado = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavIdestado_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
            dynavIdcidade.CurrentValue = cgiGet( dynavIdcidade_Internalname);
            AV6IdCidade = (short)(Math.Round(NumberUtil.Val( cgiGet( dynavIdcidade_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6IdCidade", StringUtil.LTrimStr( (decimal)(AV6IdCidade), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E120L2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7AoVivo = (bool)getParm(obj,0);
         AssignAttri("", false, "AV7AoVivo", AV7AoVivo);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0L2( ) ;
         WS0L2( ) ;
         WE0L2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202482519411124", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("webpanels/buscavelorio.js", "?202482519411124", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavIdestado.Name = "vIDESTADO";
         dynavIdestado.WebTags = "";
         dynavIdestado.removeAllItems();
         /* Using cursor H000L5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            dynavIdestado.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H000L5_A61IdEstado[0]), 4, 0)), H000L5_A62NomeEstado[0], 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( dynavIdestado.ItemCount > 0 )
         {
            AV5IdEstado = (short)(Math.Round(NumberUtil.Val( dynavIdestado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5IdEstado), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5IdEstado", StringUtil.LTrimStr( (decimal)(AV5IdEstado), 4, 0));
         }
         dynavIdcidade.Name = "vIDCIDADE";
         dynavIdcidade.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         imgImage1_Internalname = "IMAGE1";
         divTable2_Internalname = "TABLE2";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         divTable8_Internalname = "TABLE8";
         dynavIdestado_Internalname = "vIDESTADO";
         divTable5_Internalname = "TABLE5";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTable7_Internalname = "TABLE7";
         dynavIdcidade_Internalname = "vIDCIDADE";
         divTable6_Internalname = "TABLE6";
         divTable3_Internalname = "TABLE3";
         bttBuscarcerimonia_Internalname = "BUSCARCERIMONIA";
         divTable4_Internalname = "TABLE4";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         dynavIdcidade_Jsonclick = "";
         dynavIdcidade.Enabled = 1;
         dynavIdestado_Jsonclick = "";
         dynavIdestado.Enabled = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Idestado( )
      {
         AV5IdEstado = (short)(Math.Round(NumberUtil.Val( dynavIdestado.CurrentValue, "."), 18, MidpointRounding.ToEven));
         AV6IdCidade = (short)(Math.Round(NumberUtil.Val( dynavIdcidade.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXVvIDCIDADE_html0L2( AV5IdEstado) ;
         dynload_actions( ) ;
         if ( dynavIdcidade.ItemCount > 0 )
         {
            AV6IdCidade = (short)(Math.Round(NumberUtil.Val( dynavIdcidade.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavIdcidade.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV6IdCidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6IdCidade), 4, 0, ".", "")));
         dynavIdcidade.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6IdCidade), 4, 0));
         AssignProp("", false, dynavIdcidade_Internalname, "Values", dynavIdcidade.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynavIdestado"},{"av":"AV5IdEstado","fld":"vIDESTADO","pic":"ZZZ9"}]}""");
         setEventMetadata("'BUSCAR CERIMONIA'","""{"handler":"E110L1","iparms":[{"av":"dynavIdcidade"},{"av":"AV6IdCidade","fld":"vIDCIDADE","pic":"ZZZ9"}]}""");
         setEventMetadata("VALIDV_IDESTADO","""{"handler":"Validv_Idestado","iparms":[{"av":"dynavIdestado"},{"av":"AV5IdEstado","fld":"vIDESTADO","pic":"ZZZ9"},{"av":"dynavIdcidade"},{"av":"AV6IdCidade","fld":"vIDCIDADE","pic":"ZZZ9"}]""");
         setEventMetadata("VALIDV_IDESTADO",""","oparms":[{"av":"dynavIdcidade"},{"av":"AV6IdCidade","fld":"vIDCIDADE","pic":"ZZZ9"}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         imgImage1_gximage = "";
         StyleString = "";
         sImgUrl = "";
         lblTextblock2_Jsonclick = "";
         TempTags = "";
         lblTextblock3_Jsonclick = "";
         bttBuscarcerimonia_Jsonclick = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H000L2_A61IdEstado = new short[1] ;
         H000L2_A62NomeEstado = new string[] {""} ;
         H000L3_A64IdCidade = new short[1] ;
         H000L3_A65NomeCidade = new string[] {""} ;
         H000L3_A61IdEstado = new short[1] ;
         H000L4_A61IdEstado = new short[1] ;
         H000L4_A62NomeEstado = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H000L5_A61IdEstado = new short[1] ;
         H000L5_A62NomeEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webpanels.buscavelorio__default(),
            new Object[][] {
                new Object[] {
               H000L2_A61IdEstado, H000L2_A62NomeEstado
               }
               , new Object[] {
               H000L3_A64IdCidade, H000L3_A65NomeCidade, H000L3_A61IdEstado
               }
               , new Object[] {
               H000L4_A61IdEstado, H000L4_A62NomeEstado
               }
               , new Object[] {
               H000L5_A61IdEstado, H000L5_A62NomeEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV5IdEstado ;
      private short wbEnd ;
      private short wbStart ;
      private short AV6IdCidade ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short ZV6IdCidade ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string ClassString ;
      private string imgImage1_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string divTable1_Internalname ;
      private string divTable3_Internalname ;
      private string divTable5_Internalname ;
      private string divTable8_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string dynavIdestado_Internalname ;
      private string TempTags ;
      private string dynavIdestado_Jsonclick ;
      private string divTable6_Internalname ;
      private string divTable7_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string dynavIdcidade_Internalname ;
      private string dynavIdcidade_Jsonclick ;
      private string divTable4_Internalname ;
      private string bttBuscarcerimonia_Internalname ;
      private string bttBuscarcerimonia_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private bool AV7AoVivo ;
      private bool wcpOAV7AoVivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavIdestado ;
      private GXCombobox dynavIdcidade ;
      private IDataStoreProvider pr_default ;
      private short[] H000L2_A61IdEstado ;
      private string[] H000L2_A62NomeEstado ;
      private short[] H000L3_A64IdCidade ;
      private string[] H000L3_A65NomeCidade ;
      private short[] H000L3_A61IdEstado ;
      private short[] H000L4_A61IdEstado ;
      private string[] H000L4_A62NomeEstado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H000L5_A61IdEstado ;
      private string[] H000L5_A62NomeEstado ;
   }

   public class buscavelorio__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000L2;
          prmH000L2 = new Object[] {
          };
          Object[] prmH000L3;
          prmH000L3 = new Object[] {
          new ParDef("@AV5IdEstado",GXType.Int16,4,0)
          };
          Object[] prmH000L4;
          prmH000L4 = new Object[] {
          };
          Object[] prmH000L5;
          prmH000L5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000L2", "SELECT [IdEstado], [NomeEstado] FROM [Estados] ORDER BY [NomeEstado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L3", "SELECT [IdCidade], [NomeCidade], [IdEstado] FROM [EstadosId] WHERE [IdEstado] = @AV5IdEstado ORDER BY [NomeCidade] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L4", "SELECT [IdEstado], [NomeEstado] FROM [Estados] ORDER BY [NomeEstado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000L5", "SELECT [IdEstado], [NomeEstado] FROM [Estados] ORDER BY [NomeEstado] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000L5,0, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
       }
    }

 }

}
