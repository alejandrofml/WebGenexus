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
   public class administrardatos : GXDataArea
   {
      public administrardatos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public administrardatos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA122( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START122( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 239440), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
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
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("administrardatos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "VENTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8VentaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "EVENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2TipoEspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7PaisId), 4, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE122( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT122( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("administrardatos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AdministrarDatos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Administrar Datos" ;
      }

      protected void WB120( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMassiveremoveinsert_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBorrardatos_Internalname, "", "Borrar Datos", bttBorrardatos_Jsonclick, 5, "Borrar Datos", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BORRAR DATOS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AdministrarDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCargardatos_Internalname, "", "Cargar Datos", bttCargardatos_Jsonclick, 5, "Cargar Datos", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CARGAR DATOS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AdministrarDatos.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START122( )
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
         Form.Meta.addItem("description", "Administrar Datos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP120( ) ;
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
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
                           else if ( StringUtil.StrCmp(sEvt, "'BORRAR DATOS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Borrar Datos' */
                              E11122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CARGAR DATOS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cargar Datos' */
                              E12122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E13122 ();
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
      }

      protected void WE122( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA122( )
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
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13122 ();
            WB120( ) ;
         }
      }

      protected void send_integrity_lvl_hashes122( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E11122( )
      {
         /* 'Borrar Datos' Routine */
         returnInSub = false;
         /* Using cursor H00122 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A8VentaId = H00122_A8VentaId[0];
            AV12venta.Load(A8VentaId);
            AV12venta.Delete();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor H00123 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            A6InvitacionId = H00123_A6InvitacionId[0];
            AV7invitacion.Load(A6InvitacionId);
            AV7invitacion.Delete();
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor H00124 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A3EventoId = H00124_A3EventoId[0];
            AV6evento.Load(A3EventoId);
            AV6evento.Delete();
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H00125 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A5SectorId = H00125_A5SectorId[0];
            AV10sector.Load(A5SectorId);
            AV10sector.Delete();
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor H00126 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            A4LugarId = H00126_A4LugarId[0];
            AV8lugar.Load(A4LugarId);
            AV8lugar.Delete();
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Using cursor H00127 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A1EspectaculoId = H00127_A1EspectaculoId[0];
            AV5espectaculo.Load(A1EspectaculoId);
            AV5espectaculo.Delete();
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor H00128 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            A2TipoEspectaculoId = H00128_A2TipoEspectaculoId[0];
            AV11tipoEspectaculo.Load(A2TipoEspectaculoId);
            AV11tipoEspectaculo.Delete();
            pr_default.readNext(6);
         }
         pr_default.close(6);
         /* Using cursor H00129 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            A7PaisId = H00129_A7PaisId[0];
            AV9pais.Load(A7PaisId);
            AV9pais.Delete();
            pr_default.readNext(7);
         }
         pr_default.close(7);
         context.CommitDataStores("administrardatos",pr_default);
      }

      protected void E12122( )
      {
         /* 'Cargar Datos' Routine */
         returnInSub = false;
         GXt_objcol_SdtPais1 = AV14Paises;
         new pais_dataprovider(context ).execute( out  GXt_objcol_SdtPais1) ;
         AV14Paises = GXt_objcol_SdtPais1;
         AV14Paises.Insert();
         GXt_objcol_SdtLugar2 = AV13Lugares;
         new lugar_dataprovider(context ).execute( out  GXt_objcol_SdtLugar2) ;
         AV13Lugares = GXt_objcol_SdtLugar2;
         AV13Lugares.Insert();
         GXt_objcol_SdtTipoEspectaculo3 = AV15tiposEspectaculo;
         new tipoespectaculo_dataprovider(context ).execute( out  GXt_objcol_SdtTipoEspectaculo3) ;
         AV15tiposEspectaculo = GXt_objcol_SdtTipoEspectaculo3;
         AV15tiposEspectaculo.Insert();
         context.CommitDataStores("administrardatos",pr_default);
      }

      protected void nextLoad( )
      {
      }

      protected void E13122( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219513773", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("administrardatos.js", "?202481219513774", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBorrardatos_Internalname = "BORRARDATOS";
         bttCargardatos_Internalname = "CARGARDATOS";
         divMassiveremoveinsert_Internalname = "MASSIVEREMOVEINSERT";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Administrar Datos";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("'BORRAR DATOS'","""{"handler":"E11122","iparms":[{"av":"A8VentaId","fld":"VENTAID","pic":"ZZZ9"},{"av":"A6InvitacionId","fld":"INVITACIONID","pic":"ZZZ9"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"},{"av":"A2TipoEspectaculoId","fld":"TIPOESPECTACULOID","pic":"ZZZ9"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("'CARGAR DATOS'","""{"handler":"E12122","iparms":[]}""");
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
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBorrardatos_Jsonclick = "";
         bttCargardatos_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H00122_A8VentaId = new short[1] ;
         AV12venta = new SdtVenta(context);
         H00123_A6InvitacionId = new short[1] ;
         AV7invitacion = new SdtInvitacion(context);
         H00124_A3EventoId = new short[1] ;
         AV6evento = new SdtEvento(context);
         H00125_A5SectorId = new short[1] ;
         AV10sector = new SdtSector(context);
         H00126_A4LugarId = new short[1] ;
         AV8lugar = new SdtLugar(context);
         H00127_A1EspectaculoId = new short[1] ;
         AV5espectaculo = new SdtEspectaculo(context);
         H00128_A2TipoEspectaculoId = new short[1] ;
         AV11tipoEspectaculo = new SdtTipoEspectaculo(context);
         H00129_A7PaisId = new short[1] ;
         AV9pais = new SdtPais(context);
         AV14Paises = new GXBCCollection<SdtPais>( context, "Pais", "TallerGeneXus");
         GXt_objcol_SdtPais1 = new GXBCCollection<SdtPais>( context, "Pais", "TallerGeneXus");
         AV13Lugares = new GXBCCollection<SdtLugar>( context, "Lugar", "TallerGeneXus");
         GXt_objcol_SdtLugar2 = new GXBCCollection<SdtLugar>( context, "Lugar", "TallerGeneXus");
         AV15tiposEspectaculo = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "TallerGeneXus");
         GXt_objcol_SdtTipoEspectaculo3 = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "TallerGeneXus");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.administrardatos__default(),
            new Object[][] {
                new Object[] {
               H00122_A8VentaId
               }
               , new Object[] {
               H00123_A6InvitacionId
               }
               , new Object[] {
               H00124_A3EventoId
               }
               , new Object[] {
               H00125_A5SectorId
               }
               , new Object[] {
               H00126_A4LugarId
               }
               , new Object[] {
               H00127_A1EspectaculoId
               }
               , new Object[] {
               H00128_A2TipoEspectaculoId
               }
               , new Object[] {
               H00129_A7PaisId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short A8VentaId ;
      private short A6InvitacionId ;
      private short A3EventoId ;
      private short A5SectorId ;
      private short A4LugarId ;
      private short A1EspectaculoId ;
      private short A2TipoEspectaculoId ;
      private short A7PaisId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMassiveremoveinsert_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBorrardatos_Internalname ;
      private string bttBorrardatos_Jsonclick ;
      private string bttCargardatos_Internalname ;
      private string bttCargardatos_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00122_A8VentaId ;
      private SdtVenta AV12venta ;
      private short[] H00123_A6InvitacionId ;
      private SdtInvitacion AV7invitacion ;
      private short[] H00124_A3EventoId ;
      private SdtEvento AV6evento ;
      private short[] H00125_A5SectorId ;
      private SdtSector AV10sector ;
      private short[] H00126_A4LugarId ;
      private SdtLugar AV8lugar ;
      private short[] H00127_A1EspectaculoId ;
      private SdtEspectaculo AV5espectaculo ;
      private short[] H00128_A2TipoEspectaculoId ;
      private SdtTipoEspectaculo AV11tipoEspectaculo ;
      private short[] H00129_A7PaisId ;
      private SdtPais AV9pais ;
      private GXBCCollection<SdtPais> AV14Paises ;
      private GXBCCollection<SdtPais> GXt_objcol_SdtPais1 ;
      private GXBCCollection<SdtLugar> AV13Lugares ;
      private GXBCCollection<SdtLugar> GXt_objcol_SdtLugar2 ;
      private GXBCCollection<SdtTipoEspectaculo> AV15tiposEspectaculo ;
      private GXBCCollection<SdtTipoEspectaculo> GXt_objcol_SdtTipoEspectaculo3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class administrardatos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00122;
          prmH00122 = new Object[] {
          };
          Object[] prmH00123;
          prmH00123 = new Object[] {
          };
          Object[] prmH00124;
          prmH00124 = new Object[] {
          };
          Object[] prmH00125;
          prmH00125 = new Object[] {
          };
          Object[] prmH00126;
          prmH00126 = new Object[] {
          };
          Object[] prmH00127;
          prmH00127 = new Object[] {
          };
          Object[] prmH00128;
          prmH00128 = new Object[] {
          };
          Object[] prmH00129;
          prmH00129 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00122", "SELECT [VentaId] FROM [Venta] ORDER BY [VentaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00123", "SELECT [InvitacionId] FROM [Invitacion] ORDER BY [InvitacionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00123,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00124", "SELECT [EventoId] FROM [Evento] ORDER BY [EventoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00124,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00125", "SELECT [SectorId] FROM [Sector] ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00125,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00126", "SELECT [LugarId] FROM [Lugar] ORDER BY [LugarId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00126,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00127", "SELECT [EspectaculoId] FROM [Espectaculo] ORDER BY [EspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00127,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00128", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] ORDER BY [TipoEspectaculoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00128,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00129", "SELECT [PaisId] FROM [Pais] ORDER BY [PaisId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00129,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
