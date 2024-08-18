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
   public class invitacion : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A3EventoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EventoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
            A5SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A3EventoId, A5SectorId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7InvitacionId = (short)(Math.Round(NumberUtil.Val( GetPar( "InvitacionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InvitacionId", StringUtil.LTrimStr( (decimal)(AV7InvitacionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_10-184260", 0) ;
            }
         }
         Form.Meta.addItem("description", "Invitacion", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvitacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public invitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public invitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_InvitacionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7InvitacionId = aP1_InvitacionId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkInvitacionNominada = new GXCheckbox();
         dynEventoId = new GXCombobox();
         dynSectorId = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         A19InvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( A19InvitacionNominada));
         AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
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

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invitación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtInvitacionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionNombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvitacionNombre_Internalname, A18InvitacionNombre, StringUtil.RTrim( context.localUtil.Format( A18InvitacionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionNombre_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "Nombre", "start", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkInvitacionNominada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkInvitacionNominada_Internalname, "Nominada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkInvitacionNominada_Internalname, StringUtil.BoolToStr( A19InvitacionNominada), "", "Nominada", 1, chkInvitacionNominada.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(39, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,39);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEventoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEventoId_Internalname, "Evento Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEventoId, dynEventoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0)), 1, dynEventoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEventoId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Invitacion.htm");
         dynEventoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0));
         AssignProp("", false, dynEventoId_Internalname, "Values", (string)(dynEventoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynSectorId, dynSectorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0)), 1, dynSectorId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSectorId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Invitacion.htm");
         dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0));
         AssignProp("", false, dynSectorId_Internalname, "Values", (string)(dynSectorId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z6InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z6InvitacionId"), ".", ","), 18, MidpointRounding.ToEven));
               Z18InvitacionNombre = cgiGet( "Z18InvitacionNombre");
               Z19InvitacionNominada = StringUtil.StrToBool( cgiGet( "Z19InvitacionNominada"));
               Z3EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z3EventoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z5SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N3EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N3EventoId"), ".", ","), 18, MidpointRounding.ToEven));
               N5SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N5SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINVITACIONID"), ".", ","), 18, MidpointRounding.ToEven));
               A6InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EVENTOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A18InvitacionNombre = cgiGet( edtInvitacionNombre_Internalname);
               AssignAttri("", false, "A18InvitacionNombre", A18InvitacionNombre);
               A19InvitacionNominada = StringUtil.StrToBool( cgiGet( chkInvitacionNominada_Internalname));
               AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
               dynEventoId.CurrentValue = cgiGet( dynEventoId_Internalname);
               A3EventoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynEventoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
               dynSectorId.CurrentValue = cgiGet( dynSectorId_Internalname);
               A5SectorId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynSectorId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("invitacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A6InvitacionId = (short)(Math.Round(NumberUtil.Val( GetPar( "InvitacionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A6InvitacionId", StringUtil.LTrimStr( (decimal)(A6InvitacionId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll035( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes035( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls035( ) ;
            }
            else
            {
               CheckExtendedTable035( ) ;
               CloseExtendedTableCursors035( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EventoId = 0;
         AssignAttri("", false, "AV11Insert_EventoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EventoId), 4, 0));
         AV12Insert_SectorId = 0;
         AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EventoId") == 0 )
               {
                  AV11Insert_EventoId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EventoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EventoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SectorId") == 0 )
               {
                  AV12Insert_SectorId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinvitacion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18InvitacionNombre = T00033_A18InvitacionNombre[0];
               Z19InvitacionNominada = T00033_A19InvitacionNominada[0];
               Z3EventoId = T00033_A3EventoId[0];
               Z5SectorId = T00033_A5SectorId[0];
            }
            else
            {
               Z18InvitacionNombre = A18InvitacionNombre;
               Z19InvitacionNominada = A19InvitacionNominada;
               Z3EventoId = A3EventoId;
               Z5SectorId = A5SectorId;
            }
         }
         if ( GX_JID == -10 )
         {
            Z6InvitacionId = A6InvitacionId;
            Z18InvitacionNombre = A18InvitacionNombre;
            Z19InvitacionNominada = A19InvitacionNominada;
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvitacionId) )
         {
            A6InvitacionId = AV7InvitacionId;
            AssignAttri("", false, "A6InvitacionId", StringUtil.LTrimStr( (decimal)(A6InvitacionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EventoId) )
         {
            dynEventoId.Enabled = 0;
            AssignProp("", false, dynEventoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEventoId.Enabled), 5, 0), true);
         }
         else
         {
            dynEventoId.Enabled = 1;
            AssignProp("", false, dynEventoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEventoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            dynSectorId.Enabled = 0;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         }
         else
         {
            dynSectorId.Enabled = 1;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            A5SectorId = AV12Insert_SectorId;
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EventoId) )
         {
            A3EventoId = AV11Insert_EventoId;
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "Invitacion";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load035( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A18InvitacionNombre = T00035_A18InvitacionNombre[0];
            AssignAttri("", false, "A18InvitacionNombre", A18InvitacionNombre);
            A19InvitacionNominada = T00035_A19InvitacionNominada[0];
            AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
            A3EventoId = T00035_A3EventoId[0];
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
            A5SectorId = T00035_A5SectorId[0];
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
            ZM035( -10) ;
         }
         pr_default.close(3);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
         AV14Pgmname = "Invitacion";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable035( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Invitacion";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'EventoSector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = dynEventoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors035( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( short A3EventoId ,
                                short A5SectorId )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'EventoSector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = dynEventoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey035( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 10) ;
            RcdFound5 = 1;
            A6InvitacionId = T00033_A6InvitacionId[0];
            A18InvitacionNombre = T00033_A18InvitacionNombre[0];
            AssignAttri("", false, "A18InvitacionNombre", A18InvitacionNombre);
            A19InvitacionNominada = T00033_A19InvitacionNominada[0];
            AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
            A3EventoId = T00033_A3EventoId[0];
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
            A5SectorId = T00033_A5SectorId[0];
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
            Z6InvitacionId = A6InvitacionId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load035( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey035( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey035( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6InvitacionId[0] < A6InvitacionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6InvitacionId[0] > A6InvitacionId ) ) )
            {
               A6InvitacionId = T00038_A6InvitacionId[0];
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6InvitacionId[0] > A6InvitacionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6InvitacionId[0] < A6InvitacionId ) ) )
            {
               A6InvitacionId = T00039_A6InvitacionId[0];
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey035( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInvitacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert035( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A6InvitacionId != Z6InvitacionId )
               {
                  A6InvitacionId = Z6InvitacionId;
                  AssignAttri("", false, "A6InvitacionId", StringUtil.LTrimStr( (decimal)(A6InvitacionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvitacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update035( ) ;
                  GX_FocusControl = edtInvitacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A6InvitacionId != Z6InvitacionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtInvitacionNombre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert035( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInvitacionNombre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert035( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A6InvitacionId != Z6InvitacionId )
         {
            A6InvitacionId = Z6InvitacionId;
            AssignAttri("", false, "A6InvitacionId", StringUtil.LTrimStr( (decimal)(A6InvitacionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvitacionNombre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A6InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18InvitacionNombre, T00032_A18InvitacionNombre[0]) != 0 ) || ( Z19InvitacionNominada != T00032_A19InvitacionNominada[0] ) || ( Z3EventoId != T00032_A3EventoId[0] ) || ( Z5SectorId != T00032_A5SectorId[0] ) )
            {
               if ( StringUtil.StrCmp(Z18InvitacionNombre, T00032_A18InvitacionNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"InvitacionNombre");
                  GXUtil.WriteLogRaw("Old: ",Z18InvitacionNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A18InvitacionNombre[0]);
               }
               if ( Z19InvitacionNominada != T00032_A19InvitacionNominada[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"InvitacionNominada");
                  GXUtil.WriteLogRaw("Old: ",Z19InvitacionNominada);
                  GXUtil.WriteLogRaw("Current: ",T00032_A19InvitacionNominada[0]);
               }
               if ( Z3EventoId != T00032_A3EventoId[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EventoId");
                  GXUtil.WriteLogRaw("Old: ",Z3EventoId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A3EventoId[0]);
               }
               if ( Z5SectorId != T00032_A5SectorId[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z5SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A5SectorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A3EventoId, A5SectorId});
                     A6InvitacionId = T000310_A6InvitacionId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A3EventoId, A5SectorId, A6InvitacionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void delete( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000312 */
                  pr_default.execute(10, new Object[] {A6InvitacionId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel035( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Invitacion";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete035( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("invitacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("invitacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart035( )
      {
         /* Scan By routine */
         /* Using cursor T000313 */
         pr_default.execute(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = T000313_A6InvitacionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = T000313_A6InvitacionId[0];
         }
      }

      protected void ScanEnd035( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
         edtInvitacionNombre_Enabled = 0;
         AssignProp("", false, edtInvitacionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionNombre_Enabled), 5, 0), true);
         chkInvitacionNominada.Enabled = 0;
         AssignProp("", false, chkInvitacionNominada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvitacionNominada.Enabled), 5, 0), true);
         dynEventoId.Enabled = 0;
         AssignProp("", false, dynEventoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEventoId.Enabled), 5, 0), true);
         dynSectorId.Enabled = 0;
         AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
      {
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
         MasterPageObj.master_styles();
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("invitacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z6InvitacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6InvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18InvitacionNombre", Z18InvitacionNombre);
         GxWebStd.gx_boolean_hidden_field( context, "Z19InvitacionNominada", Z19InvitacionNominada);
         GxWebStd.gx_hidden_field( context, "Z3EventoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N3EventoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N5SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vINVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_EVENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SectorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         return formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Invitacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invitacion" ;
      }

      protected void InitializeNonKey035( )
      {
         A3EventoId = 0;
         AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         A5SectorId = 0;
         AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         A18InvitacionNombre = "";
         AssignAttri("", false, "A18InvitacionNombre", A18InvitacionNombre);
         A19InvitacionNominada = false;
         AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
         Z18InvitacionNombre = "";
         Z19InvitacionNominada = false;
         Z3EventoId = 0;
         Z5SectorId = 0;
      }

      protected void InitAll035( )
      {
         A6InvitacionId = 0;
         AssignAttri("", false, "A6InvitacionId", StringUtil.LTrimStr( (decimal)(A6InvitacionId), 4, 0));
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219512926", true, true);
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
         context.AddJavascriptSource("invitacion.js", "?202481219512927", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE";
         chkInvitacionNominada_Internalname = "INVITACIONNOMINADA";
         dynEventoId_Internalname = "EVENTOID";
         dynSectorId_Internalname = "SECTORID";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Invitacion";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynSectorId_Jsonclick = "";
         dynSectorId.Enabled = 1;
         dynEventoId_Jsonclick = "";
         dynEventoId.Enabled = 1;
         chkInvitacionNominada.Enabled = 1;
         edtInvitacionNombre_Jsonclick = "";
         edtInvitacionNombre_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLASECTORID031( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASECTORID_data031( ) ;
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

      protected void GXASECTORID_html031( )
      {
         short gxdynajaxvalue;
         GXDLASECTORID_data031( ) ;
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
      }

      protected void GXDLASECTORID_data031( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000314 */
         pr_default.execute(12);
         while ( (pr_default.getStatus(12) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000314_A5SectorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000314_A10SectorNombre[0]);
            pr_default.readNext(12);
         }
         pr_default.close(12);
      }

      protected void GXDLAEVENTOID031( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAEVENTOID_data031( ) ;
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

      protected void GXAEVENTOID_html031( )
      {
         short gxdynajaxvalue;
         GXDLAEVENTOID_data031( ) ;
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
      }

      protected void GXDLAEVENTOID_data031( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000315 */
         pr_default.execute(13);
         while ( (pr_default.getStatus(13) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000315_A3EventoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000315_A3EventoId[0]), 4, 0, ".", "")));
            pr_default.readNext(13);
         }
         pr_default.close(13);
      }

      protected void init_web_controls( )
      {
         chkInvitacionNominada.Name = "INVITACIONNOMINADA";
         chkInvitacionNominada.WebTags = "";
         chkInvitacionNominada.Caption = "Nominada";
         AssignProp("", false, chkInvitacionNominada_Internalname, "TitleCaption", chkInvitacionNominada.Caption, true);
         chkInvitacionNominada.CheckedValue = "false";
         A19InvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( A19InvitacionNominada));
         AssignAttri("", false, "A19InvitacionNominada", A19InvitacionNominada);
         dynEventoId.Name = "EVENTOID";
         dynEventoId.WebTags = "";
         dynEventoId.removeAllItems();
         /* Using cursor T000316 */
         pr_default.execute(14);
         while ( (pr_default.getStatus(14) != 101) )
         {
            dynEventoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000316_A3EventoId[0]), 4, 0)), StringUtil.Str( (decimal)(T000316_A3EventoId[0]), 4, 0), 0);
            pr_default.readNext(14);
         }
         pr_default.close(14);
         if ( dynEventoId.ItemCount > 0 )
         {
            A3EventoId = (short)(Math.Round(NumberUtil.Val( dynEventoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A3EventoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         }
         dynSectorId.Name = "SECTORID";
         dynSectorId.WebTags = "";
         dynSectorId.removeAllItems();
         /* Using cursor T000317 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000317_A5SectorId[0]), 4, 0)), T000317_A10SectorNombre[0], 0);
            pr_default.readNext(15);
         }
         pr_default.close(15);
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5SectorId", StringUtil.LTrimStr( (decimal)(A5SectorId), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Sectorid( )
      {
         A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A3EventoId = (short)(Math.Round(NumberUtil.Val( dynEventoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000318 */
         pr_default.execute(16, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'EventoSector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = dynEventoId_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7InvitacionId","fld":"vINVITACIONID","pic":"ZZZ9","hsh":true},{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7InvitacionId","fld":"vINVITACIONID","pic":"ZZZ9","hsh":true},{"av":"A6InvitacionId","fld":"INVITACIONID","pic":"ZZZ9"},{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12032","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]}""");
         setEventMetadata("VALID_EVENTOID","""{"handler":"Valid_Eventoid","iparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]""");
         setEventMetadata("VALID_EVENTOID",""","oparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]}""");
         setEventMetadata("VALID_SECTORID","""{"handler":"Valid_Sectorid","iparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]""");
         setEventMetadata("VALID_SECTORID",""","oparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"dynEventoId"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A19InvitacionNominada","fld":"INVITACIONNOMINADA"}]}""");
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

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z18InvitacionNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A18InvitacionNombre = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00035_A6InvitacionId = new short[1] ;
         T00035_A18InvitacionNombre = new string[] {""} ;
         T00035_A19InvitacionNominada = new bool[] {false} ;
         T00035_A3EventoId = new short[1] ;
         T00035_A5SectorId = new short[1] ;
         T00034_A3EventoId = new short[1] ;
         T00036_A3EventoId = new short[1] ;
         T00037_A6InvitacionId = new short[1] ;
         T00033_A6InvitacionId = new short[1] ;
         T00033_A18InvitacionNombre = new string[] {""} ;
         T00033_A19InvitacionNominada = new bool[] {false} ;
         T00033_A3EventoId = new short[1] ;
         T00033_A5SectorId = new short[1] ;
         T00038_A6InvitacionId = new short[1] ;
         T00039_A6InvitacionId = new short[1] ;
         T00032_A6InvitacionId = new short[1] ;
         T00032_A18InvitacionNombre = new string[] {""} ;
         T00032_A19InvitacionNominada = new bool[] {false} ;
         T00032_A3EventoId = new short[1] ;
         T00032_A5SectorId = new short[1] ;
         T000310_A6InvitacionId = new short[1] ;
         T000313_A6InvitacionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000314_A5SectorId = new short[1] ;
         T000314_A10SectorNombre = new string[] {""} ;
         T000315_A3EventoId = new short[1] ;
         T000316_A3EventoId = new short[1] ;
         T000317_A5SectorId = new short[1] ;
         T000317_A10SectorNombre = new string[] {""} ;
         T000318_A3EventoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitacion__default(),
            new Object[][] {
                new Object[] {
               T00032_A6InvitacionId, T00032_A18InvitacionNombre, T00032_A19InvitacionNominada, T00032_A3EventoId, T00032_A5SectorId
               }
               , new Object[] {
               T00033_A6InvitacionId, T00033_A18InvitacionNombre, T00033_A19InvitacionNominada, T00033_A3EventoId, T00033_A5SectorId
               }
               , new Object[] {
               T00034_A3EventoId
               }
               , new Object[] {
               T00035_A6InvitacionId, T00035_A18InvitacionNombre, T00035_A19InvitacionNominada, T00035_A3EventoId, T00035_A5SectorId
               }
               , new Object[] {
               T00036_A3EventoId
               }
               , new Object[] {
               T00037_A6InvitacionId
               }
               , new Object[] {
               T00038_A6InvitacionId
               }
               , new Object[] {
               T00039_A6InvitacionId
               }
               , new Object[] {
               T000310_A6InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A6InvitacionId
               }
               , new Object[] {
               T000314_A5SectorId, T000314_A10SectorNombre
               }
               , new Object[] {
               T000315_A3EventoId
               }
               , new Object[] {
               T000316_A3EventoId
               }
               , new Object[] {
               T000317_A5SectorId, T000317_A10SectorNombre
               }
               , new Object[] {
               T000318_A3EventoId
               }
            }
         );
         AV14Pgmname = "Invitacion";
      }

      private short wcpOAV7InvitacionId ;
      private short Z6InvitacionId ;
      private short Z3EventoId ;
      private short Z5SectorId ;
      private short N3EventoId ;
      private short N5SectorId ;
      private short GxWebError ;
      private short A3EventoId ;
      private short A5SectorId ;
      private short AV7InvitacionId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A6InvitacionId ;
      private short AV11Insert_EventoId ;
      private short AV12Insert_SectorId ;
      private short RcdFound5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvitacionNombre_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvitacionNombre_Internalname ;
      private string dynEventoId_Internalname ;
      private string dynSectorId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtInvitacionNombre_Jsonclick ;
      private string chkInvitacionNominada_Internalname ;
      private string dynEventoId_Jsonclick ;
      private string dynSectorId_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private bool Z19InvitacionNominada ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A19InvitacionNominada ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z18InvitacionNombre ;
      private string A18InvitacionNombre ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkInvitacionNominada ;
      private GXCombobox dynEventoId ;
      private GXCombobox dynSectorId ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T00035_A6InvitacionId ;
      private string[] T00035_A18InvitacionNombre ;
      private bool[] T00035_A19InvitacionNominada ;
      private short[] T00035_A3EventoId ;
      private short[] T00035_A5SectorId ;
      private short[] T00034_A3EventoId ;
      private short[] T00036_A3EventoId ;
      private short[] T00037_A6InvitacionId ;
      private short[] T00033_A6InvitacionId ;
      private string[] T00033_A18InvitacionNombre ;
      private bool[] T00033_A19InvitacionNominada ;
      private short[] T00033_A3EventoId ;
      private short[] T00033_A5SectorId ;
      private short[] T00038_A6InvitacionId ;
      private short[] T00039_A6InvitacionId ;
      private short[] T00032_A6InvitacionId ;
      private string[] T00032_A18InvitacionNombre ;
      private bool[] T00032_A19InvitacionNominada ;
      private short[] T00032_A3EventoId ;
      private short[] T00032_A5SectorId ;
      private short[] T000310_A6InvitacionId ;
      private short[] T000313_A6InvitacionId ;
      private short[] T000314_A5SectorId ;
      private string[] T000314_A10SectorNombre ;
      private short[] T000315_A3EventoId ;
      private short[] T000316_A3EventoId ;
      private short[] T000317_A5SectorId ;
      private string[] T000317_A10SectorNombre ;
      private short[] T000318_A3EventoId ;
   }

   public class invitacion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [EventoId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT TM1.[InvitacionId], TM1.[InvitacionNombre], TM1.[InvitacionNominada], TM1.[EventoId], TM1.[SectorId] FROM [Invitacion] TM1 WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [EventoId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] > @InvitacionId) ORDER BY [InvitacionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] < @InvitacionId) ORDER BY [InvitacionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Invitacion]([InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId]) VALUES(@InvitacionNombre, @InvitacionNominada, @EventoId, @SectorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000311", "UPDATE [Invitacion] SET [InvitacionNombre]=@InvitacionNombre, [InvitacionNominada]=@InvitacionNominada, [EventoId]=@EventoId, [SectorId]=@SectorId  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "SELECT [InvitacionId] FROM [Invitacion] ORDER BY [InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000314", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT [EventoId] FROM [Evento] ORDER BY [EventoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [EventoId] FROM [Evento] ORDER BY [EventoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "SELECT [EventoId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
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
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
