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
namespace GeneXus.Programs {
   public class testevalidador : GXHttpHandler
   {
      public testevalidador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design.GoldLegacy", true);
      }

      public testevalidador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_HoraInicio )
      {
         this.AV10HoraInicio = aP0_HoraInicio;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavAovivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "HoraInicio");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "HoraInicio");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "HoraInicio");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
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
               AV10HoraInicio = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( gxfirstwebparm));
               AssignAttri("", false, edtavHorainicio_Internalname, context.localUtil.TToC( AV10HoraInicio, 0, 5, 0, 3, "/", ":", " "));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_6 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_6"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_6_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_6_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_6_idx = GetPar( "sGXsfl_6_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         AV11DataVelorio = context.localUtil.ParseDateParm( GetPar( "DataVelorio"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( AV11DataVelorio, Gx_date) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
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
            PA0R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               Gx_date = DateTimeUtil.Today( context);
               WS0R2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE0R2( ) ;
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
         context.SendWebValue( "Teste Validador") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 1318140), false, true);
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("testevalidador.aspx", new object[] {UrlEncode(DateTimeUtil.FormatDateTimeParm(AV10HoraInicio))}, new string[] {"HoraInicio"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vDATAVELORIO", context.localUtil.DToC( AV11DataVelorio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATAVELORIO", GetSecureSignedToken( "", AV11DataVelorio, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_6", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_6), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDATAVELORIO", context.localUtil.DToC( AV11DataVelorio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATAVELORIO", GetSecureSignedToken( "", AV11DataVelorio, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected void RenderHtmlCloseForm0R2( )
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
         return "TesteValidador" ;
      }

      public override string GetPgmdesc( )
      {
         return "Teste Validador" ;
      }

      protected void WB0R0( )
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
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl6( ) ;
         }
         if ( wbEnd == 6 )
         {
            wbEnd = 0;
            nRC_GXsfl_6 = (int)(nGXsfl_6_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 6 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0R2( )
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
         Form.Meta.addItem("description", "Teste Validador", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0R0( ) ;
      }

      protected void WS0R2( )
      {
         START0R2( ) ;
         EVT0R2( ) ;
      }

      protected void EVT0R2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                        {
                           nGXsfl_6_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
                           SubsflControlProps_62( ) ;
                           A2Nome = cgiGet( edtNome_Internalname);
                           A57HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraInicio_Internalname), 0));
                           A58HoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHoraFim_Internalname), 0));
                           AV15AoVivo = StringUtil.StrToBool( cgiGet( chkavAovivo_Internalname));
                           AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
                           AV5CurrentTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCurrenttime_Internalname), 0));
                           AssignAttri("", false, edtavCurrenttime_Internalname, context.localUtil.TToC( AV5CurrentTime, 0, 5, 0, 3, "/", ":", " "));
                           AV10HoraInicio = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavHorainicio_Internalname), 0));
                           AssignAttri("", false, edtavHorainicio_Internalname, context.localUtil.TToC( AV10HoraInicio, 0, 5, 0, 3, "/", ":", " "));
                           sEvtType = StringUtil.Right( sEvt, 1);
                           if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                           {
                              sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                              if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                              {
                                 context.wbHandled = 1;
                                 dynload_actions( ) ;
                                 /* Execute user event: Grid1.Load */
                                 E110R2 ();
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
                              }
                           }
                           else
                           {
                           }
                        }
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE0R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0R2( ) ;
            }
         }
      }

      protected void PA0R2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_62( ) ;
         while ( nGXsfl_6_idx <= nRC_GXsfl_6 )
         {
            sendrow_62( ) ;
            nGXsfl_6_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_6_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_6_idx+1);
            sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
            SubsflControlProps_62( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( DateTime AV11DataVelorio ,
                                        DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void RF0R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 6;
         nGXsfl_6_idx = 1;
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         bGXsfl_6_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_62( ) ;
            /* Using cursor H000R2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A58HoraFim = H000R2_A58HoraFim[0];
               A57HoraInicio = H000R2_A57HoraInicio[0];
               A2Nome = H000R2_A2Nome[0];
               /* Execute user event: Grid1.Load */
               E110R2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 6;
            WB0R0( ) ;
         }
         bGXsfl_6_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0R2( )
      {
         GxWebStd.gx_hidden_field( context, "vDATAVELORIO", context.localUtil.DToC( AV11DataVelorio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vDATAVELORIO", GetSecureSignedToken( "", AV11DataVelorio, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         edtNome_Enabled = 0;
         edtHoraInicio_Enabled = 0;
         edtHoraFim_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_6 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_6"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E110R2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV5CurrentTime = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AssignAttri("", false, edtavCurrenttime_Internalname, context.localUtil.TToC( AV5CurrentTime, 0, 5, 0, 3, "/", ":", " "));
         AV15AoVivo = false;
         AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
         AV10HoraInicio = A57HoraInicio;
         AssignAttri("", false, edtavHorainicio_Internalname, context.localUtil.TToC( AV10HoraInicio, 0, 5, 0, 3, "/", ":", " "));
         AV8HoraFim = A58HoraFim;
         if ( ( AV5CurrentTime > AV10HoraInicio ) && ( AV5CurrentTime < AV8HoraFim ) && ( DateTimeUtil.ResetTime ( AV11DataVelorio ) == DateTimeUtil.ResetTime ( Gx_date ) ) )
         {
            AV15AoVivo = true;
            AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
         }
         else
         {
            AV15AoVivo = false;
            AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 6;
         }
         sendrow_62( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_6_Refreshing )
         {
            DoAjaxLoad(6, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10HoraInicio = (DateTime)getParm(obj,0);
         AssignAttri("", false, edtavHorainicio_Internalname, context.localUtil.TToC( AV10HoraInicio, 0, 5, 0, 3, "/", ":", " "));
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
         PA0R2( ) ;
         WS0R2( ) ;
         WE0R2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202482519411162", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("testevalidador.js", "?202482519411162", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_62( )
      {
         edtNome_Internalname = "NOME_"+sGXsfl_6_idx;
         edtHoraInicio_Internalname = "HORAINICIO_"+sGXsfl_6_idx;
         edtHoraFim_Internalname = "HORAFIM_"+sGXsfl_6_idx;
         chkavAovivo_Internalname = "vAOVIVO_"+sGXsfl_6_idx;
         edtavCurrenttime_Internalname = "vCURRENTTIME_"+sGXsfl_6_idx;
         edtavHorainicio_Internalname = "vHORAINICIO_"+sGXsfl_6_idx;
      }

      protected void SubsflControlProps_fel_62( )
      {
         edtNome_Internalname = "NOME_"+sGXsfl_6_fel_idx;
         edtHoraInicio_Internalname = "HORAINICIO_"+sGXsfl_6_fel_idx;
         edtHoraFim_Internalname = "HORAFIM_"+sGXsfl_6_fel_idx;
         chkavAovivo_Internalname = "vAOVIVO_"+sGXsfl_6_fel_idx;
         edtavCurrenttime_Internalname = "vCURRENTTIME_"+sGXsfl_6_fel_idx;
         edtavHorainicio_Internalname = "vHORAINICIO_"+sGXsfl_6_fel_idx;
      }

      protected void sendrow_62( )
      {
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         WB0R0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_6_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_6_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNome_Internalname,(string)A2Nome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHoraInicio_Internalname,context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A57HoraInicio, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHoraInicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)false,(string)"GeneXus\\Time",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtHoraFim_Internalname,context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A58HoraFim, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtHoraFim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)false,(string)"GeneXus\\Time",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vAOVIVO_" + sGXsfl_6_idx;
         chkavAovivo.Name = GXCCtl;
         chkavAovivo.WebTags = "";
         chkavAovivo.Caption = "";
         AssignProp("", false, chkavAovivo_Internalname, "TitleCaption", chkavAovivo.Caption, !bGXsfl_6_Refreshing);
         chkavAovivo.CheckedValue = "false";
         AV15AoVivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV15AoVivo));
         AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
         Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavAovivo_Internalname,StringUtil.BoolToStr( AV15AoVivo),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCurrenttime_Internalname,context.localUtil.TToC( AV5CurrentTime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( AV5CurrentTime, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCurrenttime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)false,(string)"GeneXus\\Time",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHorainicio_Internalname,context.localUtil.TToC( AV10HoraInicio, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( AV10HoraInicio, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHorainicio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
         send_integrity_lvl_hashes0R2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_6_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_6_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_6_idx+1);
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         /* End function sendrow_62 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vAOVIVO_" + sGXsfl_6_idx;
         chkavAovivo.Name = GXCCtl;
         chkavAovivo.WebTags = "";
         chkavAovivo.Caption = "";
         AssignProp("", false, chkavAovivo_Internalname, "TitleCaption", chkavAovivo.Caption, !bGXsfl_6_Refreshing);
         chkavAovivo.CheckedValue = "false";
         AV15AoVivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV15AoVivo));
         AssignAttri("", false, chkavAovivo_Internalname, AV15AoVivo);
         /* End function init_web_controls */
      }

      protected void StartGridControl6( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"6\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Hora Inicio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Hora Fim") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Ao Vivo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Time") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Hora Inicio") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "Grid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A2Nome));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A57HoraInicio, 10, 8, 0, 3, "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A58HoraFim, 10, 8, 0, 3, "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV15AoVivo)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( AV5CurrentTime, 10, 8, 0, 3, "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( AV10HoraInicio, 10, 8, 0, 3, "/", ":", " ")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtNome_Internalname = "NOME";
         edtHoraInicio_Internalname = "HORAINICIO";
         edtHoraFim_Internalname = "HORAFIM";
         chkavAovivo_Internalname = "vAOVIVO";
         edtavCurrenttime_Internalname = "vCURRENTTIME";
         edtavHorainicio_Internalname = "vHORAINICIO";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Design.GoldLegacy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavHorainicio_Jsonclick = "";
         edtavCurrenttime_Jsonclick = "";
         chkavAovivo.Caption = "";
         edtHoraFim_Jsonclick = "";
         edtHoraInicio_Jsonclick = "";
         edtNome_Jsonclick = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         edtHoraFim_Enabled = 0;
         edtHoraInicio_Enabled = 0;
         edtNome_Enabled = 0;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]}""");
         setEventMetadata("GRID1.LOAD","""{"handler":"E110R2","iparms":[{"av":"A57HoraInicio","fld":"HORAINICIO","pic":"99:99"},{"av":"A58HoraFim","fld":"HORAFIM","pic":"99:99"},{"av":"AV11DataVelorio","fld":"vDATAVELORIO","hsh":true},{"av":"Gx_date","fld":"vTODAY","hsh":true}]""");
         setEventMetadata("GRID1.LOAD",""","oparms":[{"av":"AV5CurrentTime","fld":"vCURRENTTIME","pic":"99:99"},{"av":"AV15AoVivo","fld":"vAOVIVO"},{"av":"AV10HoraInicio","fld":"vHORAINICIO","pic":"99:99"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Horainicio","iparms":[]}""");
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
         wcpOAV10HoraInicio = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV11DataVelorio = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         sPrefix = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A2Nome = "";
         A57HoraInicio = (DateTime)(DateTime.MinValue);
         A58HoraFim = (DateTime)(DateTime.MinValue);
         AV5CurrentTime = (DateTime)(DateTime.MinValue);
         H000R2_A55IdTransmissao = new short[1] ;
         H000R2_A58HoraFim = new DateTime[] {DateTime.MinValue} ;
         H000R2_A57HoraInicio = new DateTime[] {DateTime.MinValue} ;
         H000R2_A2Nome = new string[] {""} ;
         AV8HoraFim = (DateTime)(DateTime.MinValue);
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.testevalidador__default(),
            new Object[][] {
                new Object[] {
               H000R2_A55IdTransmissao, H000R2_A58HoraFim, H000R2_A57HoraInicio, H000R2_A2Nome
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_6 ;
      private int nGXsfl_6_idx=1 ;
      private int subGrid1_Islastpage ;
      private int edtNome_Enabled ;
      private int edtHoraInicio_Enabled ;
      private int edtHoraFim_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string edtavHorainicio_Internalname ;
      private string sGXsfl_6_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtNome_Internalname ;
      private string edtHoraInicio_Internalname ;
      private string edtHoraFim_Internalname ;
      private string chkavAovivo_Internalname ;
      private string edtavCurrenttime_Internalname ;
      private string sGXsfl_6_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtNome_Jsonclick ;
      private string edtHoraInicio_Jsonclick ;
      private string edtHoraFim_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string edtavCurrenttime_Jsonclick ;
      private string edtavHorainicio_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV10HoraInicio ;
      private DateTime wcpOAV10HoraInicio ;
      private DateTime A57HoraInicio ;
      private DateTime A58HoraFim ;
      private DateTime AV5CurrentTime ;
      private DateTime AV8HoraFim ;
      private DateTime AV11DataVelorio ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV15AoVivo ;
      private bool bGXsfl_6_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A2Nome ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAovivo ;
      private IDataStoreProvider pr_default ;
      private short[] H000R2_A55IdTransmissao ;
      private DateTime[] H000R2_A58HoraFim ;
      private DateTime[] H000R2_A57HoraInicio ;
      private string[] H000R2_A2Nome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class testevalidador__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000R2;
          prmH000R2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000R2", "SELECT [IdTransmissao], [HoraFim], [HoraInicio], [Nome] FROM [GerenciadorDeTransmissoes] ORDER BY [IdTransmissao] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000R2,11, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
