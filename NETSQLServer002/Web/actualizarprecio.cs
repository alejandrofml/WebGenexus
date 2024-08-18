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
   public class actualizarprecio : GXDataArea
   {
      public actualizarprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public actualizarprecio( IGxContext context )
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
         dynPaisId = new GXCombobox();
         dynEventoId = new GXCombobox();
         dynSectorId = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"EVENTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLAEVENTOID172( ) ;
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
         PA172( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START172( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actualizarprecio.aspx") +"\">") ;
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
            WE172( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT172( ) ;
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
         return formatLink("actualizarprecio.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ActualizarPrecio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Actualizar Precio" ;
      }

      protected void WB170( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynPaisId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynPaisId_Internalname, "Pais Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynPaisId, dynPaisId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0)), 1, dynPaisId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynPaisId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", false, 0, "HLP_ActualizarPrecio.htm");
            dynPaisId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0));
            AssignProp("", false, dynPaisId_Internalname, "Values", (string)(dynPaisId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEventoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynEventoId_Internalname, "Evento Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynEventoId, dynEventoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0)), 1, dynEventoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEventoId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "", false, 0, "HLP_ActualizarPrecio.htm");
            dynEventoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0));
            AssignProp("", false, dynEventoId_Internalname, "Values", (string)(dynEventoId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynSectorId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynSectorId, dynSectorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0)), 1, dynSectorId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSectorId.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", false, 0, "HLP_ActualizarPrecio.htm");
            dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0));
            AssignProp("", false, dynSectorId_Internalname, "Values", (string)(dynSectorId.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavPorcentaje_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPorcentaje_Internalname, "Porcentaje", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPorcentaje_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Porcentaje), 4, 0, ".", "")), StringUtil.LTrim( ((edtavPorcentaje_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5Porcentaje), "ZZZ9") : context.localUtil.Format( (decimal)(AV5Porcentaje), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPorcentaje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPorcentaje_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, false, "", "end", false, "", "HLP_ActualizarPrecio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAplicar_Internalname, "", "Aplicar", bttAplicar_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'APLICAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ActualizarPrecio.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START172( )
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
         Form.Meta.addItem("description", "Actualizar Precio", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP170( ) ;
      }

      protected void WS172( )
      {
         START172( ) ;
         EVT172( ) ;
      }

      protected void EVT172( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E11172 ();
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
                           else if ( StringUtil.StrCmp(sEvt, "'APLICAR'") == 0 )
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE172( )
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

      protected void PA172( )
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
               GX_FocusControl = edtavPorcentaje_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLASECTORID171( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASECTORID_data171( ) ;
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

      protected void GXASECTORID_html171( )
      {
         short gxdynajaxvalue;
         GXDLASECTORID_data171( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSectorId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
      }

      protected void GXDLASECTORID_data171( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00172 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00172_A5SectorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00172_A10SectorNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLAPAISID171( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAPAISID_data171( ) ;
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

      protected void GXAPAISID_html171( )
      {
         short gxdynajaxvalue;
         GXDLAPAISID_data171( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynPaisId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynPaisId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynPaisId.ItemCount > 0 )
         {
            A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         }
      }

      protected void GXDLAPAISID_data171( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00173 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00173_A7PaisId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00173_A11PaisNombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLAEVENTOID172( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAEVENTOID_data172( ) ;
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

      protected void GXAEVENTOID_html172( )
      {
         short gxdynajaxvalue;
         GXDLAEVENTOID_data172( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEventoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEventoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynEventoId.ItemCount > 0 )
         {
            A3EventoId = (short)(Math.Round(NumberUtil.Val( dynEventoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         }
      }

      protected void GXDLAEVENTOID_data172( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00174 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00174_A3EventoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00174_A14EspectaculoNombre[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXAEVENTOID_html172( ) ;
            dynSectorId.Name = "SECTORID";
            dynSectorId.WebTags = "";
            dynSectorId.removeAllItems();
            /* Using cursor H00175 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00175_A5SectorId[0]), 4, 0)), H00175_A10SectorNombre[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynSectorId.ItemCount > 0 )
            {
               A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
            }
            dynPaisId.Name = "PAISID";
            dynPaisId.WebTags = "";
            dynPaisId.removeAllItems();
            /* Using cursor H00176 */
            pr_default.execute(4);
            while ( (pr_default.getStatus(4) != 101) )
            {
               dynPaisId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00176_A7PaisId[0]), 4, 0)), H00176_A11PaisNombre[0], 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( dynPaisId.ItemCount > 0 )
            {
               A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynPaisId.ItemCount > 0 )
         {
            A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynPaisId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0));
            AssignProp("", false, dynPaisId_Internalname, "Values", dynPaisId.ToJavascriptSource(), true);
         }
         if ( dynEventoId.ItemCount > 0 )
         {
            A3EventoId = (short)(Math.Round(NumberUtil.Val( dynEventoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEventoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0));
            AssignProp("", false, dynEventoId_Internalname, "Values", dynEventoId.ToJavascriptSource(), true);
         }
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0));
            AssignProp("", false, dynSectorId_Internalname, "Values", dynSectorId.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF172( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF172( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00177 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A4LugarId = H00177_A4LugarId[0];
               A5SectorId = H00177_A5SectorId[0];
               AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
               A3EventoId = H00177_A3EventoId[0];
               AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
               A7PaisId = H00177_A7PaisId[0];
               AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
               A4LugarId = H00177_A4LugarId[0];
               A7PaisId = H00177_A7PaisId[0];
               AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
               GXAEVENTOID_html172( ) ;
               /* Execute user event: Load */
               E11172 ();
               pr_default.readNext(5);
            }
            pr_default.close(5);
            WB170( ) ;
         }
      }

      protected void send_integrity_lvl_hashes172( )
      {
      }

      protected void before_start_formulas( )
      {
         GXAEVENTOID_html172( ) ;
         /* Using cursor H00178 */
         pr_default.execute(6, new Object[] {A3EventoId});
         A4LugarId = H00178_A4LugarId[0];
         pr_default.close(6);
         /* Using cursor H00179 */
         pr_default.execute(7, new Object[] {A4LugarId});
         A7PaisId = H00179_A7PaisId[0];
         AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         pr_default.close(7);
         dynPaisId.Enabled = 0;
         AssignProp("", false, dynPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynPaisId.Enabled), 5, 0), true);
         dynEventoId.Enabled = 0;
         AssignProp("", false, dynEventoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEventoId.Enabled), 5, 0), true);
         dynSectorId.Enabled = 0;
         AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP170( )
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
            GXAEVENTOID_html172( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E11172( )
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
         PA172( ) ;
         WS172( ) ;
         WE172( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20248171237026", true, true);
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
         context.AddJavascriptSource("actualizarprecio.js", "?20248171237026", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynPaisId.Name = "PAISID";
         dynPaisId.WebTags = "";
         dynPaisId.removeAllItems();
         /* Using cursor H001710 */
         pr_default.execute(8);
         while ( (pr_default.getStatus(8) != 101) )
         {
            dynPaisId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H001710_A7PaisId[0]), 4, 0)), H001710_A11PaisNombre[0], 0);
            pr_default.readNext(8);
         }
         pr_default.close(8);
         if ( dynPaisId.ItemCount > 0 )
         {
            A7PaisId = (short)(Math.Round(NumberUtil.Val( dynPaisId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A7PaisId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A7PaisId", StringUtil.LTrimStr( (decimal)(A7PaisId), 4, 0));
         }
         dynEventoId.Name = "EVENTOID";
         dynEventoId.WebTags = "";
         dynSectorId.Name = "SECTORID";
         dynSectorId.WebTags = "";
         dynSectorId.removeAllItems();
         /* Using cursor H001711 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H001711_A5SectorId[0]), 4, 0)), H001711_A10SectorNombre[0], 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynPaisId_Internalname = "PAISID";
         dynEventoId_Internalname = "EVENTOID";
         dynSectorId_Internalname = "SECTORID";
         edtavPorcentaje_Internalname = "vPORCENTAJE";
         bttAplicar_Internalname = "APLICAR";
         divMaintable_Internalname = "MAINTABLE";
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
         edtavPorcentaje_Jsonclick = "";
         edtavPorcentaje_Enabled = 1;
         dynSectorId_Jsonclick = "";
         dynSectorId.Enabled = 0;
         dynEventoId_Jsonclick = "";
         dynEventoId.Enabled = 0;
         dynPaisId_Jsonclick = "";
         dynPaisId.Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Actualizar Precio";
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynPaisId"},{"av":"A7PaisId","fld":"PAISID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_EVENTOID","""{"handler":"Valid_Eventoid","iparms":[]}""");
         setEventMetadata("VALIDV_PORCENTAJE","""{"handler":"Validv_Porcentaje","iparms":[]}""");
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
         bttAplicar_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         H00172_A5SectorId = new short[1] ;
         H00172_A10SectorNombre = new string[] {""} ;
         H00173_A7PaisId = new short[1] ;
         H00173_A11PaisNombre = new string[] {""} ;
         H00174_A1EspectaculoId = new short[1] ;
         H00174_A3EventoId = new short[1] ;
         H00174_A14EspectaculoNombre = new string[] {""} ;
         H00175_A5SectorId = new short[1] ;
         H00175_A10SectorNombre = new string[] {""} ;
         H00176_A7PaisId = new short[1] ;
         H00176_A11PaisNombre = new string[] {""} ;
         H00177_A4LugarId = new short[1] ;
         H00177_A5SectorId = new short[1] ;
         H00177_A3EventoId = new short[1] ;
         H00177_A7PaisId = new short[1] ;
         H00178_A4LugarId = new short[1] ;
         H00179_A7PaisId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H001710_A7PaisId = new short[1] ;
         H001710_A11PaisNombre = new string[] {""} ;
         H001711_A5SectorId = new short[1] ;
         H001711_A10SectorNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarprecio__default(),
            new Object[][] {
                new Object[] {
               H00172_A5SectorId, H00172_A10SectorNombre
               }
               , new Object[] {
               H00173_A7PaisId, H00173_A11PaisNombre
               }
               , new Object[] {
               H00174_A1EspectaculoId, H00174_A3EventoId, H00174_A14EspectaculoNombre
               }
               , new Object[] {
               H00175_A5SectorId, H00175_A10SectorNombre
               }
               , new Object[] {
               H00176_A7PaisId, H00176_A11PaisNombre
               }
               , new Object[] {
               H00177_A4LugarId, H00177_A5SectorId, H00177_A3EventoId, H00177_A7PaisId
               }
               , new Object[] {
               H00178_A4LugarId
               }
               , new Object[] {
               H00179_A7PaisId
               }
               , new Object[] {
               H001710_A7PaisId, H001710_A11PaisNombre
               }
               , new Object[] {
               H001711_A5SectorId, H001711_A10SectorNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A7PaisId ;
      private short A3EventoId ;
      private short A5SectorId ;
      private short AV5Porcentaje ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A4LugarId ;
      private short nGXWrapped ;
      private int edtavPorcentaje_Enabled ;
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
      private string dynPaisId_Internalname ;
      private string TempTags ;
      private string dynPaisId_Jsonclick ;
      private string dynEventoId_Internalname ;
      private string dynEventoId_Jsonclick ;
      private string dynSectorId_Internalname ;
      private string dynSectorId_Jsonclick ;
      private string edtavPorcentaje_Internalname ;
      private string edtavPorcentaje_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttAplicar_Internalname ;
      private string bttAplicar_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
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
      private IGxDataStore dsDefault ;
      private GXCombobox dynPaisId ;
      private GXCombobox dynEventoId ;
      private GXCombobox dynSectorId ;
      private IDataStoreProvider pr_default ;
      private short[] H00172_A5SectorId ;
      private string[] H00172_A10SectorNombre ;
      private short[] H00173_A7PaisId ;
      private string[] H00173_A11PaisNombre ;
      private short[] H00174_A1EspectaculoId ;
      private short[] H00174_A3EventoId ;
      private string[] H00174_A14EspectaculoNombre ;
      private short[] H00175_A5SectorId ;
      private string[] H00175_A10SectorNombre ;
      private short[] H00176_A7PaisId ;
      private string[] H00176_A11PaisNombre ;
      private short[] H00177_A4LugarId ;
      private short[] H00177_A5SectorId ;
      private short[] H00177_A3EventoId ;
      private short[] H00177_A7PaisId ;
      private short[] H00178_A4LugarId ;
      private short[] H00179_A7PaisId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H001710_A7PaisId ;
      private string[] H001710_A11PaisNombre ;
      private short[] H001711_A5SectorId ;
      private string[] H001711_A10SectorNombre ;
   }

   public class actualizarprecio__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00172;
          prmH00172 = new Object[] {
          };
          Object[] prmH00173;
          prmH00173 = new Object[] {
          };
          Object[] prmH00174;
          prmH00174 = new Object[] {
          };
          Object[] prmH00175;
          prmH00175 = new Object[] {
          };
          Object[] prmH00176;
          prmH00176 = new Object[] {
          };
          Object[] prmH00177;
          prmH00177 = new Object[] {
          };
          Object[] prmH00178;
          prmH00178 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmH00179;
          prmH00179 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmH001710;
          prmH001710 = new Object[] {
          };
          Object[] prmH001711;
          prmH001711 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00172", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00172,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00173", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00173,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00174", "SELECT T2.[EspectaculoId], T1.[EventoId], T2.[EspectaculoNombre] FROM ([Evento] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) ORDER BY T2.[EspectaculoNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00174,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00175", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00175,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00176", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00176,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00177", "SELECT T2.[LugarId], T1.[SectorId], T1.[EventoId], T3.[PaisId] FROM (([EventoSector] T1 INNER JOIN [Evento] T2 ON T2.[EventoId] = T1.[EventoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T2.[LugarId]) ORDER BY T1.[EventoId], T1.[SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00177,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00178", "SELECT [LugarId] FROM [Evento] WHERE [EventoId] = @EventoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00178,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00179", "SELECT [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00179,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001710", "SELECT [PaisId], [PaisNombre] FROM [Pais] ORDER BY [PaisNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001710,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001711", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001711,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
