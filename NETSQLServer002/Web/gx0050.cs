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
   public class gx0050 : GXDataArea
   {
      public gx0050( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public gx0050( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pInvitacionId )
      {
         this.AV11pInvitacionId = 0 ;
         ExecuteImpl();
         aP0_pInvitacionId=this.AV11pInvitacionId;
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCinvitacionnominada = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pInvitacionId");
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
               gxfirstwebparm = GetFirstPar( "pInvitacionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pInvitacionId");
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
               AV11pInvitacionId = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pInvitacionId", StringUtil.LTrimStr( (decimal)(AV11pInvitacionId), 4, 0));
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cInvitacionId = (short)(Math.Round(NumberUtil.Val( GetPar( "cInvitacionId"), "."), 18, MidpointRounding.ToEven));
         AV7cInvitacionNombre = GetPar( "cInvitacionNombre");
         AV8cInvitacionNominada = StringUtil.StrToBool( GetPar( "cInvitacionNominada"));
         AV9cEventoId = (short)(Math.Round(NumberUtil.Val( GetPar( "cEventoId"), "."), 18, MidpointRounding.ToEven));
         AV10cSectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "cSectorId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA162( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START162( ) ;
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0050.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pInvitacionId,4,0))}, new string[] {"pInvitacionId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCINVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVITACIONNOMBRE", AV7cInvitacionNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCINVITACIONNOMINADA", StringUtil.BoolToStr( AV8cInvitacionNominada));
         GxWebStd.gx_hidden_field( context, "GXH_vCEVENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cEventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cSectorId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pInvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INVITACIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvitacionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVITACIONNOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divInvitacionnombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVITACIONNOMINADAFILTERCONTAINER_Class", StringUtil.RTrim( divInvitacionnominadafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "EVENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divEventoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SECTORIDFILTERCONTAINER_Class", StringUtil.RTrim( divSectoridfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE162( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT162( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("gx0050.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pInvitacionId,4,0))}, new string[] {"pInvitacionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0050" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Invitacion" ;
      }

      protected void WB160( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInvitacionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvitacionidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvitacionidfilter_Internalname, "Invitacion Id", "", "", lblLblinvitacionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11161_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvitacionid_Internalname, "Invitacion Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvitacionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvitacionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCinvitacionid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cInvitacionId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cInvitacionId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvitacionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvitacionid_Visible, edtavCinvitacionid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInvitacionnombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvitacionnombrefiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvitacionnombrefilter_Internalname, "Invitacion Nombre", "", "", lblLblinvitacionnombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12161_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvitacionnombre_Internalname, "Invitacion Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvitacionnombre_Internalname, AV7cInvitacionNombre, StringUtil.RTrim( context.localUtil.Format( AV7cInvitacionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvitacionnombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvitacionnombre_Visible, edtavCinvitacionnombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInvitacionnominadafiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvitacionnominadafiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvitacionnominadafilter_Internalname, "Invitacion Nominada", "", "", lblLblinvitacionnominadafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13161_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCinvitacionnominada_Internalname, "Invitacion Nominada", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCinvitacionnominada_Internalname, StringUtil.BoolToStr( AV8cInvitacionNominada), "", "Invitacion Nominada", chkavCinvitacionnominada.Visible, chkavCinvitacionnominada.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divEventoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEventoidfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbleventoidfilter_Internalname, "Evento Id", "", "", lblLbleventoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14161_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCeventoid_Internalname, "Evento Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCeventoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cEventoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCeventoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cEventoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV9cEventoId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCeventoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCeventoid_Visible, edtavCeventoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSectoridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSectoridfiltercontainer_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsectoridfilter_Internalname, "Sector Id", "", "", lblLblsectoridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15161_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsectorid_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsectorid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cSectorId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCsectorid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cSectorId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsectorid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsectorid_Visible, edtavCsectorid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16161_client"+"'", TempTags, "", 2, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 64 )
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
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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

      protected void START162( )
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
         Form.Meta.addItem("description", "Selection List Invitacion", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP160( ) ;
      }

      protected void WS162( )
      {
         START162( ) ;
         EVT162( ) ;
      }

      protected void EVT162( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A6InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A18InvitacionNombre = cgiGet( edtInvitacionNombre_Internalname);
                              A3EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtEventoId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17162 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18162 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cinvitacionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVITACIONID"), ".", ",") != Convert.ToDecimal( AV6cInvitacionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvitacionnombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVITACIONNOMBRE"), AV7cInvitacionNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvitacionnominada Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCINVITACIONNOMINADA")) != AV8cInvitacionNominada )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ceventoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCEVENTOID"), ".", ",") != Convert.ToDecimal( AV9cEventoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csectorid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORID"), ".", ",") != Convert.ToDecimal( AV10cSectorId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19162 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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
      }

      protected void WE162( )
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

      protected void PA162( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cInvitacionId ,
                                        string AV7cInvitacionNombre ,
                                        bool AV8cInvitacionNominada ,
                                        short AV9cEventoId ,
                                        short AV10cSectorId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF162( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")));
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
         AV8cInvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( AV8cInvitacionNominada));
         AssignAttri("", false, "AV8cInvitacionNominada", AV8cInvitacionNominada);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF162( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF162( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cInvitacionNombre ,
                                                 AV8cInvitacionNominada ,
                                                 AV9cEventoId ,
                                                 AV10cSectorId ,
                                                 A18InvitacionNombre ,
                                                 A19InvitacionNominada ,
                                                 A3EventoId ,
                                                 A5SectorId ,
                                                 AV6cInvitacionId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cInvitacionNombre = StringUtil.Concat( StringUtil.RTrim( AV7cInvitacionNombre), "%", "");
            /* Using cursor H00162 */
            pr_default.execute(0, new Object[] {AV6cInvitacionId, lV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A5SectorId = H00162_A5SectorId[0];
               A19InvitacionNominada = H00162_A19InvitacionNominada[0];
               A3EventoId = H00162_A3EventoId[0];
               A18InvitacionNombre = H00162_A18InvitacionNombre[0];
               A6InvitacionId = H00162_A6InvitacionId[0];
               /* Execute user event: Load */
               E18162 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB160( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes162( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVITACIONID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cInvitacionNombre ,
                                              AV8cInvitacionNominada ,
                                              AV9cEventoId ,
                                              AV10cSectorId ,
                                              A18InvitacionNombre ,
                                              A19InvitacionNominada ,
                                              A3EventoId ,
                                              A5SectorId ,
                                              AV6cInvitacionId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cInvitacionNombre = StringUtil.Concat( StringUtil.RTrim( AV7cInvitacionNombre), "%", "");
         /* Using cursor H00163 */
         pr_default.execute(1, new Object[] {AV6cInvitacionId, lV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId});
         GRID1_nRecordCount = H00163_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvitacionId, AV7cInvitacionNombre, AV8cInvitacionNominada, AV9cEventoId, AV10cSectorId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         edtInvitacionId_Enabled = 0;
         edtInvitacionNombre_Enabled = 0;
         edtEventoId_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP160( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17162 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvitacionid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvitacionid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVITACIONID");
               GX_FocusControl = edtavCinvitacionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cInvitacionId = 0;
               AssignAttri("", false, "AV6cInvitacionId", StringUtil.LTrimStr( (decimal)(AV6cInvitacionId), 4, 0));
            }
            else
            {
               AV6cInvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvitacionid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cInvitacionId", StringUtil.LTrimStr( (decimal)(AV6cInvitacionId), 4, 0));
            }
            AV7cInvitacionNombre = cgiGet( edtavCinvitacionnombre_Internalname);
            AssignAttri("", false, "AV7cInvitacionNombre", AV7cInvitacionNombre);
            AV8cInvitacionNominada = StringUtil.StrToBool( cgiGet( chkavCinvitacionnominada_Internalname));
            AssignAttri("", false, "AV8cInvitacionNominada", AV8cInvitacionNominada);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCeventoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCeventoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCEVENTOID");
               GX_FocusControl = edtavCeventoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cEventoId = 0;
               AssignAttri("", false, "AV9cEventoId", StringUtil.LTrimStr( (decimal)(AV9cEventoId), 4, 0));
            }
            else
            {
               AV9cEventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCeventoid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cEventoId", StringUtil.LTrimStr( (decimal)(AV9cEventoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSECTORID");
               GX_FocusControl = edtavCsectorid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cSectorId = 0;
               AssignAttri("", false, "AV10cSectorId", StringUtil.LTrimStr( (decimal)(AV10cSectorId), 4, 0));
            }
            else
            {
               AV10cSectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsectorid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10cSectorId", StringUtil.LTrimStr( (decimal)(AV10cSectorId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVITACIONID"), ".", ",") != Convert.ToDecimal( AV6cInvitacionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCINVITACIONNOMBRE"), AV7cInvitacionNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCINVITACIONNOMINADA")) != AV8cInvitacionNominada )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCEVENTOID"), ".", ",") != Convert.ToDecimal( AV9cEventoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSECTORID"), ".", ",") != Convert.ToDecimal( AV10cSectorId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E17162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17162( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Invitacion", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18162( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV13Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )), context);
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19162( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pInvitacionId = A6InvitacionId;
         AssignAttri("", false, "AV11pInvitacionId", StringUtil.LTrimStr( (decimal)(AV11pInvitacionId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pInvitacionId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pInvitacionId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11pInvitacionId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pInvitacionId", StringUtil.LTrimStr( (decimal)(AV11pInvitacionId), 4, 0));
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
         PA162( ) ;
         WS162( ) ;
         WE162( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219513785", true, true);
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
         context.AddJavascriptSource("gx0050.js", "?202481219513785", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtInvitacionId_Internalname = "INVITACIONID_"+sGXsfl_64_idx;
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE_"+sGXsfl_64_idx;
         edtEventoId_Internalname = "EVENTOID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtInvitacionId_Internalname = "INVITACIONID_"+sGXsfl_64_fel_idx;
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE_"+sGXsfl_64_fel_idx;
         edtEventoId_Internalname = "EVENTOID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         WB160( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV13Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV13Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvitacionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvitacionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvitacionNombre_Internalname,(string)A18InvitacionNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvitacionNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEventoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A3EventoId), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEventoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes162( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         chkavCinvitacionnominada.Name = "vCINVITACIONNOMINADA";
         chkavCinvitacionnominada.WebTags = "";
         chkavCinvitacionnominada.Caption = "Invitacion Nominada";
         AssignProp("", false, chkavCinvitacionnominada_Internalname, "TitleCaption", chkavCinvitacionnominada.Caption, true);
         chkavCinvitacionnominada.CheckedValue = "false";
         AV8cInvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( AV8cInvitacionNominada));
         AssignAttri("", false, "AV8cInvitacionNominada", AV8cInvitacionNominada);
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nombre") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Evento Id") ;
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
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A18InvitacionNombre));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", ""))));
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
         lblLblinvitacionidfilter_Internalname = "LBLINVITACIONIDFILTER";
         edtavCinvitacionid_Internalname = "vCINVITACIONID";
         divInvitacionidfiltercontainer_Internalname = "INVITACIONIDFILTERCONTAINER";
         lblLblinvitacionnombrefilter_Internalname = "LBLINVITACIONNOMBREFILTER";
         edtavCinvitacionnombre_Internalname = "vCINVITACIONNOMBRE";
         divInvitacionnombrefiltercontainer_Internalname = "INVITACIONNOMBREFILTERCONTAINER";
         lblLblinvitacionnominadafilter_Internalname = "LBLINVITACIONNOMINADAFILTER";
         chkavCinvitacionnominada_Internalname = "vCINVITACIONNOMINADA";
         divInvitacionnominadafiltercontainer_Internalname = "INVITACIONNOMINADAFILTERCONTAINER";
         lblLbleventoidfilter_Internalname = "LBLEVENTOIDFILTER";
         edtavCeventoid_Internalname = "vCEVENTOID";
         divEventoidfiltercontainer_Internalname = "EVENTOIDFILTERCONTAINER";
         lblLblsectoridfilter_Internalname = "LBLSECTORIDFILTER";
         edtavCsectorid_Internalname = "vCSECTORID";
         divSectoridfiltercontainer_Internalname = "SECTORIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtInvitacionId_Internalname = "INVITACIONID";
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE";
         edtEventoId_Internalname = "EVENTOID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         chkavCinvitacionnominada.Caption = "Invitacion Nominada";
         edtEventoId_Jsonclick = "";
         edtInvitacionNombre_Jsonclick = "";
         edtInvitacionId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtEventoId_Enabled = 0;
         edtInvitacionNombre_Enabled = 0;
         edtInvitacionId_Enabled = 0;
         edtavCsectorid_Jsonclick = "";
         edtavCsectorid_Enabled = 1;
         edtavCsectorid_Visible = 1;
         edtavCeventoid_Jsonclick = "";
         edtavCeventoid_Enabled = 1;
         edtavCeventoid_Visible = 1;
         chkavCinvitacionnominada.Enabled = 1;
         chkavCinvitacionnominada.Visible = 1;
         edtavCinvitacionnombre_Jsonclick = "";
         edtavCinvitacionnombre_Enabled = 1;
         edtavCinvitacionnombre_Visible = 1;
         edtavCinvitacionid_Jsonclick = "";
         edtavCinvitacionid_Enabled = 1;
         edtavCinvitacionid_Visible = 1;
         divSectoridfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divEventoidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInvitacionnominadafiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInvitacionnombrefiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         divInvitacionidfiltercontainer_Class = "AdvancedContainerItem AdvancedContainerItemExpanded";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Invitacion";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cInvitacionId","fld":"vCINVITACIONID","pic":"ZZZ9"},{"av":"AV7cInvitacionNombre","fld":"vCINVITACIONNOMBRE"},{"av":"AV9cEventoId","fld":"vCEVENTOID","pic":"ZZZ9"},{"av":"AV10cSectorId","fld":"vCSECTORID","pic":"ZZZ9"},{"av":"AV8cInvitacionNominada","fld":"vCINVITACIONNOMINADA"}]}""");
         setEventMetadata("'TOGGLE'","""{"handler":"E16161","iparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]""");
         setEventMetadata("'TOGGLE'",""","oparms":[{"av":"divAdvancedcontainer_Class","ctrl":"ADVANCEDCONTAINER","prop":"Class"},{"ctrl":"BTNTOGGLE","prop":"Class"}]}""");
         setEventMetadata("LBLINVITACIONIDFILTER.CLICK","""{"handler":"E11161","iparms":[{"av":"divInvitacionidfiltercontainer_Class","ctrl":"INVITACIONIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLINVITACIONIDFILTER.CLICK",""","oparms":[{"av":"divInvitacionidfiltercontainer_Class","ctrl":"INVITACIONIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCinvitacionid_Visible","ctrl":"vCINVITACIONID","prop":"Visible"}]}""");
         setEventMetadata("LBLINVITACIONNOMBREFILTER.CLICK","""{"handler":"E12161","iparms":[{"av":"divInvitacionnombrefiltercontainer_Class","ctrl":"INVITACIONNOMBREFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLINVITACIONNOMBREFILTER.CLICK",""","oparms":[{"av":"divInvitacionnombrefiltercontainer_Class","ctrl":"INVITACIONNOMBREFILTERCONTAINER","prop":"Class"},{"av":"edtavCinvitacionnombre_Visible","ctrl":"vCINVITACIONNOMBRE","prop":"Visible"}]}""");
         setEventMetadata("LBLINVITACIONNOMINADAFILTER.CLICK","""{"handler":"E13161","iparms":[{"av":"divInvitacionnominadafiltercontainer_Class","ctrl":"INVITACIONNOMINADAFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLINVITACIONNOMINADAFILTER.CLICK",""","oparms":[{"av":"divInvitacionnominadafiltercontainer_Class","ctrl":"INVITACIONNOMINADAFILTERCONTAINER","prop":"Class"},{"av":"chkavCinvitacionnominada.Visible","ctrl":"vCINVITACIONNOMINADA","prop":"Visible"}]}""");
         setEventMetadata("LBLEVENTOIDFILTER.CLICK","""{"handler":"E14161","iparms":[{"av":"divEventoidfiltercontainer_Class","ctrl":"EVENTOIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLEVENTOIDFILTER.CLICK",""","oparms":[{"av":"divEventoidfiltercontainer_Class","ctrl":"EVENTOIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCeventoid_Visible","ctrl":"vCEVENTOID","prop":"Visible"}]}""");
         setEventMetadata("LBLSECTORIDFILTER.CLICK","""{"handler":"E15161","iparms":[{"av":"divSectoridfiltercontainer_Class","ctrl":"SECTORIDFILTERCONTAINER","prop":"Class"}]""");
         setEventMetadata("LBLSECTORIDFILTER.CLICK",""","oparms":[{"av":"divSectoridfiltercontainer_Class","ctrl":"SECTORIDFILTERCONTAINER","prop":"Class"},{"av":"edtavCsectorid_Visible","ctrl":"vCSECTORID","prop":"Visible"}]}""");
         setEventMetadata("ENTER","""{"handler":"E19162","iparms":[{"av":"A6InvitacionId","fld":"INVITACIONID","pic":"ZZZ9","hsh":true}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV11pInvitacionId","fld":"vPINVITACIONID","pic":"ZZZ9"}]}""");
         setEventMetadata("GRID1_FIRSTPAGE","""{"handler":"subgrid1_firstpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cInvitacionId","fld":"vCINVITACIONID","pic":"ZZZ9"},{"av":"AV7cInvitacionNombre","fld":"vCINVITACIONNOMBRE"},{"av":"AV9cEventoId","fld":"vCEVENTOID","pic":"ZZZ9"},{"av":"AV10cSectorId","fld":"vCSECTORID","pic":"ZZZ9"},{"av":"AV8cInvitacionNominada","fld":"vCINVITACIONNOMINADA"}]}""");
         setEventMetadata("GRID1_PREVPAGE","""{"handler":"subgrid1_previouspage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cInvitacionId","fld":"vCINVITACIONID","pic":"ZZZ9"},{"av":"AV7cInvitacionNombre","fld":"vCINVITACIONNOMBRE"},{"av":"AV9cEventoId","fld":"vCEVENTOID","pic":"ZZZ9"},{"av":"AV10cSectorId","fld":"vCSECTORID","pic":"ZZZ9"},{"av":"AV8cInvitacionNominada","fld":"vCINVITACIONNOMINADA"}]}""");
         setEventMetadata("GRID1_NEXTPAGE","""{"handler":"subgrid1_nextpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cInvitacionId","fld":"vCINVITACIONID","pic":"ZZZ9"},{"av":"AV7cInvitacionNombre","fld":"vCINVITACIONNOMBRE"},{"av":"AV9cEventoId","fld":"vCEVENTOID","pic":"ZZZ9"},{"av":"AV10cSectorId","fld":"vCSECTORID","pic":"ZZZ9"},{"av":"AV8cInvitacionNominada","fld":"vCINVITACIONNOMINADA"}]}""");
         setEventMetadata("GRID1_LASTPAGE","""{"handler":"subgrid1_lastpage","iparms":[{"av":"GRID1_nFirstRecordOnPage"},{"av":"GRID1_nEOF"},{"av":"subGrid1_Rows","ctrl":"GRID1","prop":"Rows"},{"av":"AV6cInvitacionId","fld":"vCINVITACIONID","pic":"ZZZ9"},{"av":"AV7cInvitacionNombre","fld":"vCINVITACIONNOMBRE"},{"av":"AV9cEventoId","fld":"vCEVENTOID","pic":"ZZZ9"},{"av":"AV10cSectorId","fld":"vCSECTORID","pic":"ZZZ9"},{"av":"AV8cInvitacionNominada","fld":"vCINVITACIONNOMINADA"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Eventoid","iparms":[]}""");
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
         AV7cInvitacionNombre = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblinvitacionidfilter_Jsonclick = "";
         TempTags = "";
         lblLblinvitacionnombrefilter_Jsonclick = "";
         lblLblinvitacionnominadafilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLbleventoidfilter_Jsonclick = "";
         lblLblsectoridfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV13Linkselection_GXI = "";
         A18InvitacionNombre = "";
         lV7cInvitacionNombre = "";
         H00162_A5SectorId = new short[1] ;
         H00162_A19InvitacionNominada = new bool[] {false} ;
         H00162_A3EventoId = new short[1] ;
         H00162_A18InvitacionNombre = new string[] {""} ;
         H00162_A6InvitacionId = new short[1] ;
         H00163_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0050__default(),
            new Object[][] {
                new Object[] {
               H00162_A5SectorId, H00162_A19InvitacionNominada, H00162_A3EventoId, H00162_A18InvitacionNombre, H00162_A6InvitacionId
               }
               , new Object[] {
               H00163_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11pInvitacionId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cInvitacionId ;
      private short AV9cEventoId ;
      private short AV10cSectorId ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A6InvitacionId ;
      private short A3EventoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A5SectorId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int edtavCinvitacionid_Enabled ;
      private int edtavCinvitacionid_Visible ;
      private int edtavCinvitacionnombre_Visible ;
      private int edtavCinvitacionnombre_Enabled ;
      private int edtavCeventoid_Enabled ;
      private int edtavCeventoid_Visible ;
      private int edtavCsectorid_Enabled ;
      private int edtavCsectorid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtInvitacionId_Enabled ;
      private int edtInvitacionNombre_Enabled ;
      private int edtEventoId_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divInvitacionidfiltercontainer_Class ;
      private string divInvitacionnombrefiltercontainer_Class ;
      private string divInvitacionnominadafiltercontainer_Class ;
      private string divEventoidfiltercontainer_Class ;
      private string divSectoridfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divInvitacionidfiltercontainer_Internalname ;
      private string lblLblinvitacionidfilter_Internalname ;
      private string lblLblinvitacionidfilter_Jsonclick ;
      private string edtavCinvitacionid_Internalname ;
      private string TempTags ;
      private string edtavCinvitacionid_Jsonclick ;
      private string divInvitacionnombrefiltercontainer_Internalname ;
      private string lblLblinvitacionnombrefilter_Internalname ;
      private string lblLblinvitacionnombrefilter_Jsonclick ;
      private string edtavCinvitacionnombre_Internalname ;
      private string edtavCinvitacionnombre_Jsonclick ;
      private string divInvitacionnominadafiltercontainer_Internalname ;
      private string lblLblinvitacionnominadafilter_Internalname ;
      private string lblLblinvitacionnominadafilter_Jsonclick ;
      private string chkavCinvitacionnominada_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divEventoidfiltercontainer_Internalname ;
      private string lblLbleventoidfilter_Internalname ;
      private string lblLbleventoidfilter_Jsonclick ;
      private string edtavCeventoid_Internalname ;
      private string edtavCeventoid_Jsonclick ;
      private string divSectoridfiltercontainer_Internalname ;
      private string lblLblsectoridfilter_Internalname ;
      private string lblLblsectoridfilter_Jsonclick ;
      private string edtavCsectorid_Internalname ;
      private string edtavCsectorid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtInvitacionId_Internalname ;
      private string edtInvitacionNombre_Internalname ;
      private string edtEventoId_Internalname ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtInvitacionId_Jsonclick ;
      private string edtInvitacionNombre_Jsonclick ;
      private string edtEventoId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8cInvitacionNominada ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool A19InvitacionNominada ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cInvitacionNombre ;
      private string AV13Linkselection_GXI ;
      private string A18InvitacionNombre ;
      private string lV7cInvitacionNombre ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCinvitacionnominada ;
      private IDataStoreProvider pr_default ;
      private short[] H00162_A5SectorId ;
      private bool[] H00162_A19InvitacionNominada ;
      private short[] H00162_A3EventoId ;
      private string[] H00162_A18InvitacionNombre ;
      private short[] H00162_A6InvitacionId ;
      private long[] H00163_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pInvitacionId ;
   }

   public class gx0050__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00162( IGxContext context ,
                                             string AV7cInvitacionNombre ,
                                             bool AV8cInvitacionNominada ,
                                             short AV9cEventoId ,
                                             short AV10cSectorId ,
                                             string A18InvitacionNombre ,
                                             bool A19InvitacionNominada ,
                                             short A3EventoId ,
                                             short A5SectorId ,
                                             short AV6cInvitacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SectorId], [InvitacionNominada], [EventoId], [InvitacionNombre], [InvitacionId]";
         sFromString = " FROM [Invitacion]";
         sOrderString = "";
         AddWhere(sWhereString, "([InvitacionId] >= @AV6cInvitacionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cInvitacionNombre)) )
         {
            AddWhere(sWhereString, "([InvitacionNombre] like @lV7cInvitacionNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (false==AV8cInvitacionNominada) )
         {
            AddWhere(sWhereString, "([InvitacionNominada] >= @AV8cInvitacionNominada)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cEventoId) )
         {
            AddWhere(sWhereString, "([EventoId] >= @AV9cEventoId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cSectorId) )
         {
            AddWhere(sWhereString, "([SectorId] >= @AV10cSectorId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         sOrderString += " ORDER BY [InvitacionId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00163( IGxContext context ,
                                             string AV7cInvitacionNombre ,
                                             bool AV8cInvitacionNominada ,
                                             short AV9cEventoId ,
                                             short AV10cSectorId ,
                                             string A18InvitacionNombre ,
                                             bool A19InvitacionNominada ,
                                             short A3EventoId ,
                                             short A5SectorId ,
                                             short AV6cInvitacionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Invitacion]";
         AddWhere(sWhereString, "([InvitacionId] >= @AV6cInvitacionId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cInvitacionNombre)) )
         {
            AddWhere(sWhereString, "([InvitacionNombre] like @lV7cInvitacionNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (false==AV8cInvitacionNominada) )
         {
            AddWhere(sWhereString, "([InvitacionNominada] >= @AV8cInvitacionNominada)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cEventoId) )
         {
            AddWhere(sWhereString, "([EventoId] >= @AV9cEventoId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cSectorId) )
         {
            AddWhere(sWhereString, "([SectorId] >= @AV10cSectorId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00162(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_H00163(context, (string)dynConstraints[0] , (bool)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00162;
          prmH00162 = new Object[] {
          new ParDef("@AV6cInvitacionId",GXType.Int16,4,0) ,
          new ParDef("@lV7cInvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@AV8cInvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@AV9cEventoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cSectorId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00163;
          prmH00163 = new Object[] {
          new ParDef("@AV6cInvitacionId",GXType.Int16,4,0) ,
          new ParDef("@lV7cInvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@AV8cInvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@AV9cEventoId",GXType.Int16,4,0) ,
          new ParDef("@AV10cSectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00162", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00162,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00163", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00163,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
