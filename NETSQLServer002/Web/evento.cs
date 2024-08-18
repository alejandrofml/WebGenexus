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
   public class evento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"SECTORCUPOACTUAL") == 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            A3EventoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EventoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX11ASASECTORCUPOACTUAL023( A5SectorId, A3EventoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EspectaculoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A1EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A4LugarId = (short)(Math.Round(NumberUtil.Val( GetPar( "LugarId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A4LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A5SectorId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridevento_sectores") == 0 )
         {
            gxnrGridevento_sectores_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridevento_invitaciones") == 0 )
         {
            gxnrGridevento_invitaciones_newrow_invoke( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7EventoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EventoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7EventoId", StringUtil.LTrimStr( (decimal)(AV7EventoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vEVENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EventoId), "ZZZ9"), context));
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
         Form.Meta.addItem("description", "Evento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEventoHoraFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridevento_sectores_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridevento_sectores_newrow( ) ;
         /* End function gxnrGridevento_sectores_newrow_invoke */
      }

      protected void gxnrGridevento_invitaciones_newrow_invoke( )
      {
         nRC_GXsfl_66 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_66"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_66_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_66_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_66_idx = GetPar( "sGXsfl_66_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridevento_invitaciones_newrow( ) ;
         /* End function gxnrGridevento_invitaciones_newrow_invoke */
      }

      public evento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public evento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EventoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EventoId = aP1_EventoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynEspectaculoId = new GXCombobox();
         dynLugarId = new GXCombobox();
         dynSectorId = new GXCombobox();
         chkInvitacionNominada = new GXCheckbox();
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
         if ( dynEspectaculoId.ItemCount > 0 )
         {
            A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynEspectaculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynEspectaculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EspectaculoId), 4, 0));
            AssignProp("", false, dynEspectaculoId_Internalname, "Values", dynEspectaculoId.ToJavascriptSource(), true);
         }
         if ( dynLugarId.ItemCount > 0 )
         {
            A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynLugarId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0));
            AssignProp("", false, dynLugarId_Internalname, "Values", dynLugarId.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Evento", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Evento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Evento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEventoHoraFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEventoHoraFecha_Internalname, "Hora Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEventoHoraFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEventoHoraFecha_Internalname, context.localUtil.TToC( A17EventoHoraFecha, 10, 8, 1, 2, "/", ":", " "), context.localUtil.Format( A17EventoHoraFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',5,12,'eng',false,0);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEventoHoraFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEventoHoraFecha_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Evento.htm");
         GxWebStd.gx_bitmap( context, edtEventoHoraFecha_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEventoHoraFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Evento.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynEspectaculoId_Internalname, "Espectáculo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynEspectaculoId, dynEspectaculoId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1EspectaculoId), 4, 0)), 1, dynEspectaculoId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynEspectaculoId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Evento.htm");
         dynEspectaculoId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1EspectaculoId), 4, 0));
         AssignProp("", false, dynEspectaculoId_Internalname, "Values", (string)(dynEspectaculoId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+dynLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynLugarId_Internalname, "Lugar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynLugarId, dynLugarId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0)), 1, dynLugarId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynLugarId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Evento.htm");
         dynLugarId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0));
         AssignProp("", false, dynLugarId_Internalname, "Values", (string)(dynLugarId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectorestable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlesectores_Internalname, "Sectores", "", "", lblTitlesectores_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridevento_sectores( ) ;
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
         GxWebStd.gx_div_start( context, divInvitacionestable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleinvitaciones_Internalname, "Invitaciones", "", "", lblTitleinvitaciones_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridevento_invitaciones( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Evento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridevento_sectores( )
      {
         /*  Grid Control  */
         StartGridControl53( ) ;
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount3 = 1;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_3 = 1;
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  init_level_properties3( ) ;
                  getByPrimaryKey023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
               nBlankRcdCount3 = 1;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            sMode3 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow023( ) ;
               dynSectorId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtSectorCapacidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCAPACIDAD_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorCapacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCapacidad_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtSectorCupoActual_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCUPOACTUAL_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorCupoActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCupoActual_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtSectorPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORPRECIO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_3 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal023( ) ;
               }
               SendRow023( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount3 = 1;
            nRcdExists_3 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart023( ) ;
               while ( RcdFound3 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_533( ) ;
                  init_level_properties3( ) ;
                  standaloneNotModal023( ) ;
                  getByPrimaryKey023( ) ;
                  standaloneModal023( ) ;
                  AddRow023( ) ;
                  ScanNext023( ) ;
               }
               ScanEnd023( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode3 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_533( ) ;
            InitAll023( ) ;
            init_level_properties3( ) ;
            nRcdExists_3 = 0;
            nIsMod_3 = 0;
            nRcdDeleted_3 = 0;
            nBlankRcdCount3 = (short)(nBlankRcdUsr3+nBlankRcdCount3);
            fRowAdded = 0;
            while ( nBlankRcdCount3 > 0 )
            {
               standaloneNotModal023( ) ;
               standaloneModal023( ) ;
               AddRow023( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = dynSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount3 = (short)(nBlankRcdCount3-1);
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridevento_sectoresContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridevento_sectores", Gridevento_sectoresContainer, subGridevento_sectores_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridevento_sectoresContainerData", Gridevento_sectoresContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridevento_sectoresContainerData"+"V", Gridevento_sectoresContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridevento_sectoresContainerData"+"V"+"\" value='"+Gridevento_sectoresContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridevento_invitaciones( )
      {
         /*  Grid Control  */
         StartGridControl66( ) ;
         nGXsfl_66_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 0;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart025( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey025( ) ;
                  AddRow025( ) ;
                  ScanNext025( ) ;
               }
               ScanEnd025( ) ;
               nBlankRcdCount5 = 0;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal025( ) ;
            standaloneModal025( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_66_idx < nRC_GXsfl_66 )
            {
               bGXsfl_66_Refreshing = true;
               ReadRow025( ) ;
               edtInvitacionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONID_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
               edtInvitacionNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONNOMBRE_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvitacionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionNombre_Enabled), 5, 0), !bGXsfl_66_Refreshing);
               chkInvitacionNominada.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONNOMINADA_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkInvitacionNominada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvitacionNominada.Enabled), 5, 0), !bGXsfl_66_Refreshing);
               if ( ( nRcdExists_5 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal025( ) ;
               }
               SendRow025( ) ;
               bGXsfl_66_Refreshing = false;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 0;
            nRcdExists_5 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart025( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_665( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal025( ) ;
                  getByPrimaryKey025( ) ;
                  standaloneModal025( ) ;
                  AddRow025( ) ;
                  ScanNext025( ) ;
               }
               ScanEnd025( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode5 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx+1), 4, 0), 4, "0");
            SubsflControlProps_665( ) ;
            InitAll025( ) ;
            init_level_properties5( ) ;
            nRcdExists_5 = 0;
            nIsMod_5 = 0;
            nRcdDeleted_5 = 0;
            nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
            fRowAdded = 0;
            while ( nBlankRcdCount5 > 0 )
            {
               standaloneNotModal025( ) ;
               standaloneModal025( ) ;
               AddRow025( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtInvitacionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridevento_invitacionesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridevento_invitaciones", Gridevento_invitacionesContainer, subGridevento_invitaciones_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridevento_invitacionesContainerData", Gridevento_invitacionesContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridevento_invitacionesContainerData"+"V", Gridevento_invitacionesContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridevento_invitacionesContainerData"+"V"+"\" value='"+Gridevento_invitacionesContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z3EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z3EventoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z17EventoHoraFecha = context.localUtil.CToT( cgiGet( "Z17EventoHoraFecha"), 0);
               Z1EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               Z4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4LugarId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
               nRC_GXsfl_66 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_66"), ".", ","), 18, MidpointRounding.ToEven));
               N1EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N1EspectaculoId"), ".", ","), 18, MidpointRounding.ToEven));
               N4LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N4LugarId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vEVENTOID"), ".", ","), 18, MidpointRounding.ToEven));
               A3EventoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "EVENTOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV8Insert_EspectaculoId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ".", ","), 18, MidpointRounding.ToEven));
               AV9Insert_LugarId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_LUGARID"), ".", ","), 18, MidpointRounding.ToEven));
               AV17Pgmname = cgiGet( "vPGMNAME");
               A10SectorNombre = cgiGet( "SECTORNOMBRE");
               /* Read variables values. */
               if ( context.localUtil.VCDateTime( cgiGet( edtEventoHoraFecha_Internalname), 1, 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Evento Hora Fecha"}), 1, "EVENTOHORAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtEventoHoraFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A17EventoHoraFecha", context.localUtil.TToC( A17EventoHoraFecha, 8, 5, 1, 2, "/", ":", " "));
               }
               else
               {
                  A17EventoHoraFecha = context.localUtil.CToT( cgiGet( edtEventoHoraFecha_Internalname));
                  AssignAttri("", false, "A17EventoHoraFecha", context.localUtil.TToC( A17EventoHoraFecha, 8, 5, 1, 2, "/", ":", " "));
               }
               dynEspectaculoId.Name = dynEspectaculoId_Internalname;
               dynEspectaculoId.CurrentValue = cgiGet( dynEspectaculoId_Internalname);
               A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynEspectaculoId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               dynLugarId.Name = dynLugarId_Internalname;
               dynLugarId.CurrentValue = cgiGet( dynLugarId_Internalname);
               A4LugarId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynLugarId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Evento");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("EventoId", context.localUtil.Format( (decimal)(A3EventoId), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("evento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A3EventoId = (short)(Math.Round(NumberUtil.Val( GetPar( "EventoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode2 = Gx_mode;
            CONFIRM_023( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_025( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode2;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_025( )
      {
         nGXsfl_66_idx = 0;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            ReadRow025( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey025( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate025( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable025( ) ;
                        CloseExtendedTableCursors025( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "INVITACIONID_" + sGXsfl_66_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtInvitacionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey025( ) ;
                        Load025( ) ;
                        BeforeValidate025( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls025( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate025( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable025( ) ;
                              CloseExtendedTableCursors025( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "INVITACIONID_" + sGXsfl_66_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvitacionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInvitacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtInvitacionNombre_Internalname, A18InvitacionNombre) ;
            ChangePostValue( chkInvitacionNominada_Internalname, StringUtil.BoolToStr( A19InvitacionNominada)) ;
            ChangePostValue( "ZT_"+"Z6InvitacionId_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6InvitacionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z18InvitacionNombre_"+sGXsfl_66_idx, Z18InvitacionNombre) ;
            ChangePostValue( "ZT_"+"Z19InvitacionNominada_"+sGXsfl_66_idx, StringUtil.BoolToStr( Z19InvitacionNominada)) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "INVITACIONID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVITACIONNOMBRE_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVITACIONNOMINADA_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvitacionNominada.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_023( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "SECTORID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = dynSectorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( nRcdDeleted_3 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey023( ) ;
                        Load023( ) ;
                        BeforeValidate023( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls023( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              CloseExtendedTableCursors023( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "SECTORID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorCapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorCupoActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z5SectorId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SectorId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "SECTORID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynSectorId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCAPACIDAD_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCUPOACTUAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCupoActual_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORPRECIO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV13TrnContext.FromXml(AV15WebSession.Get("TrnContext"), null, "", "");
         AV8Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV8Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV8Insert_EspectaculoId), 4, 0));
         AV9Insert_LugarId = 0;
         AssignAttri("", false, "AV9Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV9Insert_LugarId), 4, 0));
         if ( ( StringUtil.StrCmp(AV13TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV13TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV13TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV8Insert_EspectaculoId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV8Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV8Insert_EspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "LugarId") == 0 )
               {
                  AV9Insert_LugarId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV9Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV9Insert_LugarId), 4, 0));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV13TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwevento.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z17EventoHoraFecha = T00028_A17EventoHoraFecha[0];
               Z1EspectaculoId = T00028_A1EspectaculoId[0];
               Z4LugarId = T00028_A4LugarId[0];
            }
            else
            {
               Z17EventoHoraFecha = A17EventoHoraFecha;
               Z1EspectaculoId = A1EspectaculoId;
               Z4LugarId = A4LugarId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z3EventoId = A3EventoId;
            Z17EventoHoraFecha = A17EventoHoraFecha;
            Z1EspectaculoId = A1EspectaculoId;
            Z4LugarId = A4LugarId;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EventoId) )
         {
            A3EventoId = AV7EventoId;
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV8Insert_EspectaculoId) )
         {
            dynEspectaculoId.Enabled = 0;
            AssignProp("", false, dynEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEspectaculoId.Enabled), 5, 0), true);
         }
         else
         {
            dynEspectaculoId.Enabled = 1;
            AssignProp("", false, dynEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEspectaculoId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV9Insert_LugarId) )
         {
            dynLugarId.Enabled = 0;
            AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
         }
         else
         {
            dynLugarId.Enabled = 1;
            AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV9Insert_LugarId) )
         {
            A4LugarId = AV9Insert_LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV8Insert_EspectaculoId) )
         {
            A1EspectaculoId = AV8Insert_EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
            AV17Pgmname = "Evento";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A17EventoHoraFecha = T000211_A17EventoHoraFecha[0];
            AssignAttri("", false, "A17EventoHoraFecha", context.localUtil.TToC( A17EventoHoraFecha, 8, 5, 1, 2, "/", ":", " "));
            A1EspectaculoId = T000211_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A4LugarId = T000211_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            ZM022( -12) ;
         }
         pr_default.close(9);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV17Pgmname = "Evento";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV17Pgmname = "Evento";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         if ( ! ( (DateTime.MinValue==A17EventoHoraFecha) || ( A17EventoHoraFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Field Evento Hora Fecha is out of range", "OutOfRange", 1, "EVENTOHORAFECHA");
            AnyError = 1;
            GX_FocusControl = edtEventoHoraFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(8);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(7);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( short A1EspectaculoId )
      {
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_14( short A4LugarId )
      {
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM022( 12) ;
            RcdFound2 = 1;
            A3EventoId = T00028_A3EventoId[0];
            A17EventoHoraFecha = T00028_A17EventoHoraFecha[0];
            AssignAttri("", false, "A17EventoHoraFecha", context.localUtil.TToC( A17EventoHoraFecha, 8, 5, 1, 2, "/", ":", " "));
            A1EspectaculoId = T00028_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A4LugarId = T00028_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            Z3EventoId = A3EventoId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000215 */
         pr_default.execute(13, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000215_A3EventoId[0] < A3EventoId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000215_A3EventoId[0] > A3EventoId ) ) )
            {
               A3EventoId = T000215_A3EventoId[0];
               RcdFound2 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000216 */
         pr_default.execute(14, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000216_A3EventoId[0] > A3EventoId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000216_A3EventoId[0] < A3EventoId ) ) )
            {
               A3EventoId = T000216_A3EventoId[0];
               RcdFound2 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEventoHoraFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3EventoId != Z3EventoId )
               {
                  A3EventoId = Z3EventoId;
                  AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEventoHoraFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtEventoHoraFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A3EventoId != Z3EventoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEventoHoraFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_FocusControl = edtEventoHoraFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A3EventoId != Z3EventoId )
         {
            A3EventoId = Z3EventoId;
            AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEventoHoraFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00027 */
            pr_default.execute(5, new Object[] {A3EventoId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Evento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( Z17EventoHoraFecha != T00027_A17EventoHoraFecha[0] ) || ( Z1EspectaculoId != T00027_A1EspectaculoId[0] ) || ( Z4LugarId != T00027_A4LugarId[0] ) )
            {
               if ( Z17EventoHoraFecha != T00027_A17EventoHoraFecha[0] )
               {
                  GXUtil.WriteLog("evento:[seudo value changed for attri]"+"EventoHoraFecha");
                  GXUtil.WriteLogRaw("Old: ",Z17EventoHoraFecha);
                  GXUtil.WriteLogRaw("Current: ",T00027_A17EventoHoraFecha[0]);
               }
               if ( Z1EspectaculoId != T00027_A1EspectaculoId[0] )
               {
                  GXUtil.WriteLog("evento:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z1EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00027_A1EspectaculoId[0]);
               }
               if ( Z4LugarId != T00027_A4LugarId[0] )
               {
                  GXUtil.WriteLog("evento:[seudo value changed for attri]"+"LugarId");
                  GXUtil.WriteLogRaw("Old: ",Z4LugarId);
                  GXUtil.WriteLogRaw("Current: ",T00027_A4LugarId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Evento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000217 */
                     pr_default.execute(15, new Object[] {A17EventoHoraFecha, A1EspectaculoId, A4LugarId});
                     A3EventoId = T000217_A3EventoId[0];
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Evento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption020( ) ;
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
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000218 */
                     pr_default.execute(16, new Object[] {A17EventoHoraFecha, A1EspectaculoId, A4LugarId, A3EventoId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Evento");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Evento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanNext023( ) ;
                  }
                  ScanEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000219 */
                     pr_default.execute(17, new Object[] {A3EventoId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("Evento");
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
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Evento";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {A3EventoId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow023( ) ;
            if ( ( nRcdExists_3 != 0 ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               GetKey023( ) ;
               if ( ( nRcdExists_3 == 0 ) && ( nRcdDeleted_3 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert023( ) ;
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( ( nRcdDeleted_3 != 0 ) && ( nRcdExists_3 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete023( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_3 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update023( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_3 == 0 )
                     {
                        GXCCtl = "SECTORID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = dynSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( dynSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorCapacidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorCupoActual_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", ""))) ;
            ChangePostValue( edtSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z5SectorId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SectorId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_3_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", ""))) ;
            if ( nIsMod_3 != 0 )
            {
               ChangePostValue( "SECTORID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynSectorId.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCAPACIDAD_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORCUPOACTUAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCupoActual_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "SECTORPRECIO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll023( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_3 = 0;
         nIsMod_3 = 0;
         nRcdDeleted_3 = 0;
      }

      protected void ProcessNestedLevel025( )
      {
         nGXsfl_66_idx = 0;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            ReadRow025( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal025( ) ;
               GetKey025( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert025( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete025( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update025( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "INVITACIONID_" + sGXsfl_66_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvitacionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInvitacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtInvitacionNombre_Internalname, A18InvitacionNombre) ;
            ChangePostValue( chkInvitacionNominada_Internalname, StringUtil.BoolToStr( A19InvitacionNominada)) ;
            ChangePostValue( "ZT_"+"Z6InvitacionId_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6InvitacionId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z18InvitacionNombre_"+sGXsfl_66_idx, Z18InvitacionNombre) ;
            ChangePostValue( "ZT_"+"Z19InvitacionNominada_"+sGXsfl_66_idx, StringUtil.BoolToStr( Z19InvitacionNominada)) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_66_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "INVITACIONID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVITACIONNOMBRE_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVITACIONNOMINADA_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvitacionNominada.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll025( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel023( ) ;
         ProcessNestedLevel025( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(4);
            context.CommitDataStores("evento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(4);
            context.RollbackDataStores("evento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000221 */
         pr_default.execute(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A3EventoId = T000221_A3EventoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A3EventoId = T000221_A3EventoId[0];
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtEventoHoraFecha_Enabled = 0;
         AssignProp("", false, edtEventoHoraFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEventoHoraFecha_Enabled), 5, 0), true);
         dynEspectaculoId.Enabled = 0;
         AssignProp("", false, dynEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynEspectaculoId.Enabled), 5, 0), true);
         dynLugarId.Enabled = 0;
         AssignProp("", false, dynLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynLugarId.Enabled), 5, 0), true);
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -15 )
         {
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
            Z10SectorNombre = A10SectorNombre;
            Z20SectorCapacidad = A20SectorCapacidad;
            Z21SectorPrecio = A21SectorPrecio;
         }
      }

      protected void standaloneNotModal023( )
      {
      }

      protected void standaloneModal023( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            dynSectorId.Enabled = 0;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            dynSectorId.Enabled = 1;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load023( )
      {
         /* Using cursor T000222 */
         pr_default.execute(20, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound3 = 1;
            A10SectorNombre = T000222_A10SectorNombre[0];
            A20SectorCapacidad = T000222_A20SectorCapacidad[0];
            A21SectorPrecio = T000222_A21SectorPrecio[0];
            ZM023( -15) ;
         }
         pr_default.close(20);
         OnLoadActions023( ) ;
      }

      protected void OnLoadActions023( )
      {
         GXt_int1 = A25SectorCupoActual;
         new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
         A25SectorCupoActual = GXt_int1;
      }

      protected void CheckExtendedTable023( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal023( ) ;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "SECTORID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10SectorNombre = T00026_A10SectorNombre[0];
         A20SectorCapacidad = T00026_A20SectorCapacidad[0];
         A21SectorPrecio = T00026_A21SectorPrecio[0];
         pr_default.close(4);
         nIsDirty_3 = 1;
         GXt_int1 = A25SectorCupoActual;
         new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
         A25SectorCupoActual = GXt_int1;
      }

      protected void CloseExtendedTableCursors023( )
      {
         pr_default.close(4);
      }

      protected void enableDisable023( )
      {
      }

      protected void gxLoad_16( short A5SectorId )
      {
         /* Using cursor T000223 */
         pr_default.execute(21, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GXCCtl = "SECTORID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10SectorNombre = T000223_A10SectorNombre[0];
         A20SectorCapacidad = T000223_A20SectorCapacidad[0];
         A21SectorPrecio = T000223_A21SectorPrecio[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10SectorNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey023( )
      {
         /* Using cursor T000224 */
         pr_default.execute(22, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(3) != 101) && ( T00025_A3EventoId[0] == A3EventoId ) )
         {
            ZM023( 15) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A5SectorId = T00025_A5SectorId[0];
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal023( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes023( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency023( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A3EventoId, A5SectorId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EventoSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EventoSector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM023( 0) ;
            CheckOptimisticConcurrency023( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm023( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000225 */
                     pr_default.execute(23, new Object[] {A3EventoId, A5SectorId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("EventoSector");
                     if ( (pr_default.getStatus(23) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load023( ) ;
            }
            EndLevel023( ) ;
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void Update023( )
      {
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable023( ) ;
         }
         if ( ( nIsMod_3 != 0 ) || ( nIsDirty_3 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency023( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm023( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate023( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [EventoSector] */
                        DeferredUpdate023( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey023( ) ;
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
               EndLevel023( ) ;
            }
         }
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate023( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency023( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls023( ) ;
            AfterConfirm023( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete023( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000226 */
                  pr_default.execute(24, new Object[] {A3EventoId, A5SectorId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("EventoSector");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel023( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000227 */
            pr_default.execute(25, new Object[] {A5SectorId});
            A10SectorNombre = T000227_A10SectorNombre[0];
            A20SectorCapacidad = T000227_A20SectorCapacidad[0];
            A21SectorPrecio = T000227_A21SectorPrecio[0];
            pr_default.close(25);
            GXt_int1 = A25SectorCupoActual;
            new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
            A25SectorCupoActual = GXt_int1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000228 */
            pr_default.execute(26, new Object[] {A3EventoId, A5SectorId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000229 */
            pr_default.execute(27, new Object[] {A3EventoId, A5SectorId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
         }
      }

      protected void EndLevel023( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart023( )
      {
         /* Scan By routine */
         /* Using cursor T000230 */
         pr_default.execute(28, new Object[] {A3EventoId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound3 = 1;
            A5SectorId = T000230_A5SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound3 = 1;
            A5SectorId = T000230_A5SectorId[0];
         }
      }

      protected void ScanEnd023( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm023( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert023( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate023( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete023( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete023( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate023( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes023( )
      {
         dynSectorId.Enabled = 0;
         AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtSectorCapacidad_Enabled = 0;
         AssignProp("", false, edtSectorCapacidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCapacidad_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtSectorCupoActual_Enabled = 0;
         AssignProp("", false, edtSectorCupoActual_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCupoActual_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtSectorPrecio_Enabled = 0;
         AssignProp("", false, edtSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorPrecio_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes023( )
      {
      }

      protected void ZM025( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18InvitacionNombre = T00023_A18InvitacionNombre[0];
               Z19InvitacionNominada = T00023_A19InvitacionNominada[0];
            }
            else
            {
               Z18InvitacionNombre = A18InvitacionNombre;
               Z19InvitacionNominada = A19InvitacionNominada;
            }
         }
         if ( GX_JID == -17 )
         {
            Z6InvitacionId = A6InvitacionId;
            Z18InvitacionNombre = A18InvitacionNombre;
            Z19InvitacionNominada = A19InvitacionNominada;
         }
      }

      protected void standaloneNotModal025( )
      {
      }

      protected void standaloneModal025( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtInvitacionId_Enabled = 0;
            AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         }
         else
         {
            edtInvitacionId_Enabled = 1;
            AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         }
      }

      protected void Load025( )
      {
         /* Using cursor T000231 */
         pr_default.execute(29, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound5 = 1;
            A18InvitacionNombre = T000231_A18InvitacionNombre[0];
            A19InvitacionNominada = T000231_A19InvitacionNominada[0];
            ZM025( -17) ;
         }
         pr_default.close(29);
         OnLoadActions025( ) ;
      }

      protected void OnLoadActions025( )
      {
      }

      protected void CheckExtendedTable025( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal025( ) ;
      }

      protected void CloseExtendedTableCursors025( )
      {
      }

      protected void enableDisable025( )
      {
      }

      protected void GetKey025( )
      {
         /* Using cursor T000232 */
         pr_default.execute(30, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(30);
      }

      protected void getByPrimaryKey025( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM025( 17) ;
            RcdFound5 = 1;
            InitializeNonKey025( ) ;
            A6InvitacionId = T00023_A6InvitacionId[0];
            A18InvitacionNombre = T00023_A18InvitacionNombre[0];
            A19InvitacionNominada = T00023_A19InvitacionNominada[0];
            Z6InvitacionId = A6InvitacionId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load025( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey025( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal025( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes025( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency025( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A6InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18InvitacionNombre, T00022_A18InvitacionNombre[0]) != 0 ) || ( Z19InvitacionNominada != T00022_A19InvitacionNominada[0] ) )
            {
               if ( StringUtil.StrCmp(Z18InvitacionNombre, T00022_A18InvitacionNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("evento:[seudo value changed for attri]"+"InvitacionNombre");
                  GXUtil.WriteLogRaw("Old: ",Z18InvitacionNombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A18InvitacionNombre[0]);
               }
               if ( Z19InvitacionNominada != T00022_A19InvitacionNominada[0] )
               {
                  GXUtil.WriteLog("evento:[seudo value changed for attri]"+"InvitacionNominada");
                  GXUtil.WriteLogRaw("Old: ",Z19InvitacionNominada);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19InvitacionNominada[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert025( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM025( 0) ;
            CheckOptimisticConcurrency025( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm025( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert025( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000233 */
                     pr_default.execute(31, new Object[] {A18InvitacionNombre, A19InvitacionNominada});
                     A6InvitacionId = T000233_A6InvitacionId[0];
                     pr_default.close(31);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load025( ) ;
            }
            EndLevel025( ) ;
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void Update025( )
      {
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable025( ) ;
         }
         if ( ( nIsMod_5 != 0 ) || ( nIsDirty_5 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency025( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm025( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate025( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000234 */
                        pr_default.execute(32, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A6InvitacionId});
                        pr_default.close(32);
                        pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                        if ( (pr_default.getStatus(32) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate025( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey025( ) ;
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
               EndLevel025( ) ;
            }
         }
         CloseExtendedTableCursors025( ) ;
      }

      protected void DeferredUpdate025( )
      {
      }

      protected void Delete025( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate025( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency025( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls025( ) ;
            AfterConfirm025( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete025( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000235 */
                  pr_default.execute(33, new Object[] {A6InvitacionId});
                  pr_default.close(33);
                  pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
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
         EndLevel025( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls025( )
      {
         standaloneModal025( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel025( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart025( )
      {
         /* Scan By routine */
         /* Using cursor T000236 */
         pr_default.execute(34);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = T000236_A6InvitacionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext025( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = T000236_A6InvitacionId[0];
         }
      }

      protected void ScanEnd025( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm025( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert025( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate025( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete025( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete025( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate025( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes025( )
      {
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         edtInvitacionNombre_Enabled = 0;
         AssignProp("", false, edtInvitacionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionNombre_Enabled), 5, 0), !bGXsfl_66_Refreshing);
         chkInvitacionNominada.Enabled = 0;
         AssignProp("", false, chkInvitacionNominada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvitacionNominada.Enabled), 5, 0), !bGXsfl_66_Refreshing);
      }

      protected void send_integrity_lvl_hashes025( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void SubsflControlProps_533( )
      {
         dynSectorId_Internalname = "SECTORID_"+sGXsfl_53_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_53_idx;
         edtSectorCupoActual_Internalname = "SECTORCUPOACTUAL_"+sGXsfl_53_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_533( )
      {
         dynSectorId_Internalname = "SECTORID_"+sGXsfl_53_fel_idx;
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD_"+sGXsfl_53_fel_idx;
         edtSectorCupoActual_Internalname = "SECTORCUPOACTUAL_"+sGXsfl_53_fel_idx;
         edtSectorPrecio_Internalname = "SECTORPRECIO_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow023( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_533( ) ;
         SendRow023( ) ;
      }

      protected void SendRow023( )
      {
         Gridevento_sectoresRow = GXWebRow.GetNew(context);
         if ( subGridevento_sectores_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridevento_sectores_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridevento_sectores_Class, "") != 0 )
            {
               subGridevento_sectores_Linesclass = subGridevento_sectores_Class+"Odd";
            }
         }
         else if ( subGridevento_sectores_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridevento_sectores_Backstyle = 0;
            subGridevento_sectores_Backcolor = subGridevento_sectores_Allbackcolor;
            if ( StringUtil.StrCmp(subGridevento_sectores_Class, "") != 0 )
            {
               subGridevento_sectores_Linesclass = subGridevento_sectores_Class+"Uniform";
            }
         }
         else if ( subGridevento_sectores_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridevento_sectores_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridevento_sectores_Class, "") != 0 )
            {
               subGridevento_sectores_Linesclass = subGridevento_sectores_Class+"Odd";
            }
            subGridevento_sectores_Backcolor = (int)(0x0);
         }
         else if ( subGridevento_sectores_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridevento_sectores_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridevento_sectores_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridevento_sectores_Class, "") != 0 )
               {
                  subGridevento_sectores_Linesclass = subGridevento_sectores_Class+"Even";
               }
            }
            else
            {
               subGridevento_sectores_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridevento_sectores_Class, "") != 0 )
               {
                  subGridevento_sectores_Linesclass = subGridevento_sectores_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         GXCCtl = "SECTORID_" + sGXsfl_53_idx;
         dynSectorId.Name = GXCCtl;
         dynSectorId.WebTags = "";
         dynSectorId.removeAllItems();
         /* Using cursor T000237 */
         pr_default.execute(35);
         while ( (pr_default.getStatus(35) != 101) )
         {
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000237_A5SectorId[0]), 4, 0)), T000237_A10SectorNombre[0], 0);
            pr_default.readNext(35);
         }
         pr_default.close(35);
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridevento_sectoresRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynSectorId,(string)dynSectorId_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0)),(short)1,(string)dynSectorId_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,dynSectorId.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"",(string)"",(bool)true,(short)0});
         dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0));
         AssignProp("", false, dynSectorId_Internalname, "Values", (string)(dynSectorId.ToJavascriptSource()), !bGXsfl_53_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridevento_sectoresRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorCapacidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", "")),StringUtil.LTrim( ((edtSectorCapacidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A20SectorCapacidad), "ZZZ9") : context.localUtil.Format( (decimal)(A20SectorCapacidad), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorCapacidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorCapacidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridevento_sectoresRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorCupoActual_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", "")),StringUtil.LTrim( ((edtSectorCupoActual_Enabled!=0) ? context.localUtil.Format( (decimal)(A25SectorCupoActual), "ZZZ9") : context.localUtil.Format( (decimal)(A25SectorCupoActual), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorCupoActual_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorCupoActual_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_3_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridevento_sectoresRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", "")),StringUtil.LTrim( ((edtSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A21SectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A21SectorPrecio), "ZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,57);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtSectorPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridevento_sectoresRow);
         send_integrity_lvl_hashes023( ) ;
         GXCCtl = "Z5SectorId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5SectorId), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_3), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_3_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_3), 4, 0, ".", "")));
         GXCCtl = "nIsMod_3_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_3), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_53_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV13TrnContext);
         }
         GXCCtl = "vEVENTOID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EventoId), 4, 0, ".", "")));
         GXCCtl = "EVENTOID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynSectorId.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORCAPACIDAD_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORCUPOACTUAL_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCupoActual_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORPRECIO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridevento_sectoresContainer.AddRow(Gridevento_sectoresRow);
      }

      protected void ReadRow023( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_533( ) ;
         dynSectorId.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORID_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtSectorCapacidad_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCAPACIDAD_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtSectorCupoActual_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORCUPOACTUAL_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtSectorPrecio_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "SECTORPRECIO_"+sGXsfl_53_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         dynSectorId.Name = dynSectorId_Internalname;
         dynSectorId.CurrentValue = cgiGet( dynSectorId_Internalname);
         A5SectorId = (short)(Math.Round(NumberUtil.Val( cgiGet( dynSectorId_Internalname), "."), 18, MidpointRounding.ToEven));
         A20SectorCapacidad = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCapacidad_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         A25SectorCupoActual = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorCupoActual_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         A21SectorPrecio = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorPrecio_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z5SectorId_" + sGXsfl_53_idx;
         Z5SectorId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_3_" + sGXsfl_53_idx;
         nRcdDeleted_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_3_" + sGXsfl_53_idx;
         nRcdExists_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_3_" + sGXsfl_53_idx;
         nIsMod_3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_665( )
      {
         edtInvitacionId_Internalname = "INVITACIONID_"+sGXsfl_66_idx;
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE_"+sGXsfl_66_idx;
         chkInvitacionNominada_Internalname = "INVITACIONNOMINADA_"+sGXsfl_66_idx;
      }

      protected void SubsflControlProps_fel_665( )
      {
         edtInvitacionId_Internalname = "INVITACIONID_"+sGXsfl_66_fel_idx;
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE_"+sGXsfl_66_fel_idx;
         chkInvitacionNominada_Internalname = "INVITACIONNOMINADA_"+sGXsfl_66_fel_idx;
      }

      protected void AddRow025( )
      {
         nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_665( ) ;
         SendRow025( ) ;
      }

      protected void SendRow025( )
      {
         Gridevento_invitacionesRow = GXWebRow.GetNew(context);
         if ( subGridevento_invitaciones_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridevento_invitaciones_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridevento_invitaciones_Class, "") != 0 )
            {
               subGridevento_invitaciones_Linesclass = subGridevento_invitaciones_Class+"Odd";
            }
         }
         else if ( subGridevento_invitaciones_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridevento_invitaciones_Backstyle = 0;
            subGridevento_invitaciones_Backcolor = subGridevento_invitaciones_Allbackcolor;
            if ( StringUtil.StrCmp(subGridevento_invitaciones_Class, "") != 0 )
            {
               subGridevento_invitaciones_Linesclass = subGridevento_invitaciones_Class+"Uniform";
            }
         }
         else if ( subGridevento_invitaciones_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridevento_invitaciones_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridevento_invitaciones_Class, "") != 0 )
            {
               subGridevento_invitaciones_Linesclass = subGridevento_invitaciones_Class+"Odd";
            }
            subGridevento_invitaciones_Backcolor = (int)(0x0);
         }
         else if ( subGridevento_invitaciones_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridevento_invitaciones_Backstyle = 1;
            if ( ((int)((nGXsfl_66_idx) % (2))) == 0 )
            {
               subGridevento_invitaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridevento_invitaciones_Class, "") != 0 )
               {
                  subGridevento_invitaciones_Linesclass = subGridevento_invitaciones_Class+"Even";
               }
            }
            else
            {
               subGridevento_invitaciones_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridevento_invitaciones_Class, "") != 0 )
               {
                  subGridevento_invitaciones_Linesclass = subGridevento_invitaciones_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 67,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ROClassString = "Attribute";
         Gridevento_invitacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvitacionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A6InvitacionId), "ZZZ9"))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,67);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvitacionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvitacionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)66,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ROClassString = "Attribute";
         Gridevento_invitacionesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvitacionNombre_Internalname,(string)A18InvitacionNombre,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvitacionNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvitacionNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)66,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nombre",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_66_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 69,'',false,'" + sGXsfl_66_idx + "',66)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "INVITACIONNOMINADA_" + sGXsfl_66_idx;
         chkInvitacionNominada.Name = GXCCtl;
         chkInvitacionNominada.WebTags = "";
         chkInvitacionNominada.Caption = "";
         AssignProp("", false, chkInvitacionNominada_Internalname, "TitleCaption", chkInvitacionNominada.Caption, !bGXsfl_66_Refreshing);
         chkInvitacionNominada.CheckedValue = "false";
         A19InvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( A19InvitacionNominada));
         Gridevento_invitacionesRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkInvitacionNominada_Internalname,StringUtil.BoolToStr( A19InvitacionNominada),(string)"",(string)"",(short)-1,chkInvitacionNominada.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\""});
         ajax_sending_grid_row(Gridevento_invitacionesRow);
         send_integrity_lvl_hashes025( ) ;
         GXCCtl = "Z6InvitacionId_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6InvitacionId), 4, 0, ".", "")));
         GXCCtl = "Z18InvitacionNombre_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z18InvitacionNombre);
         GXCCtl = "Z19InvitacionNominada_" + sGXsfl_66_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z19InvitacionNominada);
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ".", "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_66_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV13TrnContext);
         }
         GXCCtl = "vEVENTOID_" + sGXsfl_66_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVITACIONID_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVITACIONNOMBRE_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVITACIONNOMINADA_"+sGXsfl_66_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvitacionNominada.Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridevento_invitacionesContainer.AddRow(Gridevento_invitacionesRow);
      }

      protected void ReadRow025( )
      {
         nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_665( ) ;
         edtInvitacionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONID_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvitacionNombre_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONNOMBRE_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         chkInvitacionNominada.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVITACIONNOMINADA_"+sGXsfl_66_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "INVITACIONID_" + sGXsfl_66_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvitacionId_Internalname;
            wbErr = true;
            A6InvitacionId = 0;
         }
         else
         {
            A6InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A18InvitacionNombre = cgiGet( edtInvitacionNombre_Internalname);
         A19InvitacionNominada = StringUtil.StrToBool( cgiGet( chkInvitacionNominada_Internalname));
         GXCCtl = "Z6InvitacionId_" + sGXsfl_66_idx;
         Z6InvitacionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z18InvitacionNombre_" + sGXsfl_66_idx;
         Z18InvitacionNombre = cgiGet( GXCCtl);
         GXCCtl = "Z19InvitacionNominada_" + sGXsfl_66_idx;
         Z19InvitacionNominada = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_66_idx;
         nRcdDeleted_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_5_" + sGXsfl_66_idx;
         nRcdExists_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_5_" + sGXsfl_66_idx;
         nIsMod_5 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtInvitacionId_Enabled = edtInvitacionId_Enabled;
         defdynSectorId_Enabled = dynSectorId.Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_533( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_533( ) ;
            ChangePostValue( "Z5SectorId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z5SectorId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z5SectorId_"+sGXsfl_53_idx) ;
         }
         nGXsfl_66_idx = 0;
         sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
         SubsflControlProps_665( ) ;
         while ( nGXsfl_66_idx < nRC_GXsfl_66 )
         {
            nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_665( ) ;
            ChangePostValue( "Z6InvitacionId_"+sGXsfl_66_idx, cgiGet( "ZT_"+"Z6InvitacionId_"+sGXsfl_66_idx)) ;
            DeletePostValue( "ZT_"+"Z6InvitacionId_"+sGXsfl_66_idx) ;
            ChangePostValue( "Z18InvitacionNombre_"+sGXsfl_66_idx, cgiGet( "ZT_"+"Z18InvitacionNombre_"+sGXsfl_66_idx)) ;
            DeletePostValue( "ZT_"+"Z18InvitacionNombre_"+sGXsfl_66_idx) ;
            ChangePostValue( "Z19InvitacionNominada_"+sGXsfl_66_idx, cgiGet( "ZT_"+"Z19InvitacionNominada_"+sGXsfl_66_idx)) ;
            DeletePostValue( "ZT_"+"Z19InvitacionNominada_"+sGXsfl_66_idx) ;
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 239440), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 239440), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("evento.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EventoId,4,0))}, new string[] {"Gx_mode","EventoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Evento");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("EventoId", context.localUtil.Format( (decimal)(A3EventoId), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("evento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z3EventoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17EventoHoraFecha", context.localUtil.TToC( Z17EventoHoraFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_66", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_66_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV13TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV13TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV13TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vEVENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vEVENTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EventoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "EVENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EventoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Insert_EspectaculoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Insert_LugarId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_hidden_field( context, "SECTORNOMBRE", A10SectorNombre);
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
         return formatLink("evento.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EventoId,4,0))}, new string[] {"Gx_mode","EventoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Evento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Evento" ;
      }

      protected void InitializeNonKey022( )
      {
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A17EventoHoraFecha", context.localUtil.TToC( A17EventoHoraFecha, 8, 5, 1, 2, "/", ":", " "));
         Z17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         Z1EspectaculoId = 0;
         Z4LugarId = 0;
      }

      protected void InitAll022( )
      {
         A3EventoId = 0;
         AssignAttri("", false, "A3EventoId", StringUtil.LTrimStr( (decimal)(A3EventoId), 4, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey023( )
      {
         A25SectorCupoActual = 0;
         A10SectorNombre = "";
         AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
         A20SectorCapacidad = 0;
         A21SectorPrecio = 0;
      }

      protected void InitAll023( )
      {
         A5SectorId = 0;
         InitializeNonKey023( ) ;
      }

      protected void StandaloneModalInsert023( )
      {
      }

      protected void InitializeNonKey025( )
      {
         A18InvitacionNombre = "";
         A19InvitacionNominada = false;
         Z18InvitacionNombre = "";
         Z19InvitacionNominada = false;
      }

      protected void InitAll025( )
      {
         A6InvitacionId = 0;
         InitializeNonKey025( ) ;
      }

      protected void StandaloneModalInsert025( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202481219513810", true, true);
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
         context.AddJavascriptSource("evento.js", "?202481219513810", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties3( )
      {
         dynSectorId.Enabled = defdynSectorId_Enabled;
         AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void init_level_properties5( )
      {
         edtInvitacionId_Enabled = defedtInvitacionId_Enabled;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), !bGXsfl_66_Refreshing);
      }

      protected void StartGridControl53( )
      {
         Gridevento_sectoresContainer.AddObjectProperty("GridName", "Gridevento_sectores");
         Gridevento_sectoresContainer.AddObjectProperty("Header", subGridevento_sectores_Header);
         Gridevento_sectoresContainer.AddObjectProperty("Class", "Grid");
         Gridevento_sectoresContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Backcolorstyle), 1, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("CmpContext", "");
         Gridevento_sectoresContainer.AddObjectProperty("InMasterPage", "false");
         Gridevento_sectoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_sectoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A5SectorId), 4, 0, ".", ""))));
         Gridevento_sectoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynSectorId.Enabled), 5, 0, ".", "")));
         Gridevento_sectoresContainer.AddColumnProperties(Gridevento_sectoresColumn);
         Gridevento_sectoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_sectoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", ""))));
         Gridevento_sectoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCapacidad_Enabled), 5, 0, ".", "")));
         Gridevento_sectoresContainer.AddColumnProperties(Gridevento_sectoresColumn);
         Gridevento_sectoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_sectoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", ""))));
         Gridevento_sectoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorCupoActual_Enabled), 5, 0, ".", "")));
         Gridevento_sectoresContainer.AddColumnProperties(Gridevento_sectoresColumn);
         Gridevento_sectoresColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_sectoresColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", ""))));
         Gridevento_sectoresColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtSectorPrecio_Enabled), 5, 0, ".", "")));
         Gridevento_sectoresContainer.AddColumnProperties(Gridevento_sectoresColumn);
         Gridevento_sectoresContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Selectedindex), 4, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Allowselection), 1, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Selectioncolor), 9, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Allowhovering), 1, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Hoveringcolor), 9, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Allowcollapsing), 1, 0, ".", "")));
         Gridevento_sectoresContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_sectores_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl66( )
      {
         Gridevento_invitacionesContainer.AddObjectProperty("GridName", "Gridevento_invitaciones");
         Gridevento_invitacionesContainer.AddObjectProperty("Header", subGridevento_invitaciones_Header);
         Gridevento_invitacionesContainer.AddObjectProperty("Class", "Grid");
         Gridevento_invitacionesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Backcolorstyle), 1, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("CmpContext", "");
         Gridevento_invitacionesContainer.AddObjectProperty("InMasterPage", "false");
         Gridevento_invitacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_invitacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6InvitacionId), 4, 0, ".", ""))));
         Gridevento_invitacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionId_Enabled), 5, 0, ".", "")));
         Gridevento_invitacionesContainer.AddColumnProperties(Gridevento_invitacionesColumn);
         Gridevento_invitacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_invitacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A18InvitacionNombre));
         Gridevento_invitacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvitacionNombre_Enabled), 5, 0, ".", "")));
         Gridevento_invitacionesContainer.AddColumnProperties(Gridevento_invitacionesColumn);
         Gridevento_invitacionesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridevento_invitacionesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A19InvitacionNominada)));
         Gridevento_invitacionesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvitacionNominada.Enabled), 5, 0, ".", "")));
         Gridevento_invitacionesContainer.AddColumnProperties(Gridevento_invitacionesColumn);
         Gridevento_invitacionesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Selectedindex), 4, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Allowselection), 1, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Selectioncolor), 9, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Allowhovering), 1, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Hoveringcolor), 9, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Allowcollapsing), 1, 0, ".", "")));
         Gridevento_invitacionesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridevento_invitaciones_Collapsed), 1, 0, ".", "")));
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
         edtEventoHoraFecha_Internalname = "EVENTOHORAFECHA";
         dynEspectaculoId_Internalname = "ESPECTACULOID";
         dynLugarId_Internalname = "LUGARID";
         lblTitlesectores_Internalname = "TITLESECTORES";
         dynSectorId_Internalname = "SECTORID";
         edtSectorCapacidad_Internalname = "SECTORCAPACIDAD";
         edtSectorCupoActual_Internalname = "SECTORCUPOACTUAL";
         edtSectorPrecio_Internalname = "SECTORPRECIO";
         divSectorestable_Internalname = "SECTORESTABLE";
         lblTitleinvitaciones_Internalname = "TITLEINVITACIONES";
         edtInvitacionId_Internalname = "INVITACIONID";
         edtInvitacionNombre_Internalname = "INVITACIONNOMBRE";
         chkInvitacionNominada_Internalname = "INVITACIONNOMINADA";
         divInvitacionestable_Internalname = "INVITACIONESTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridevento_sectores_Internalname = "GRIDEVENTO_SECTORES";
         subGridevento_invitaciones_Internalname = "GRIDEVENTO_INVITACIONES";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("TallerGeneXus", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridevento_invitaciones_Allowcollapsing = 0;
         subGridevento_invitaciones_Allowselection = 0;
         subGridevento_invitaciones_Header = "";
         subGridevento_sectores_Allowcollapsing = 0;
         subGridevento_sectores_Allowselection = 0;
         subGridevento_sectores_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Evento";
         chkInvitacionNominada.Caption = "";
         edtInvitacionNombre_Jsonclick = "";
         edtInvitacionId_Jsonclick = "";
         subGridevento_invitaciones_Class = "Grid";
         subGridevento_invitaciones_Backcolorstyle = 0;
         edtSectorPrecio_Jsonclick = "";
         edtSectorCupoActual_Jsonclick = "";
         edtSectorCapacidad_Jsonclick = "";
         dynSectorId_Jsonclick = "";
         subGridevento_sectores_Class = "Grid";
         subGridevento_sectores_Backcolorstyle = 0;
         chkInvitacionNominada.Enabled = 1;
         edtInvitacionNombre_Enabled = 1;
         edtInvitacionId_Enabled = 1;
         edtSectorPrecio_Enabled = 0;
         edtSectorCupoActual_Enabled = 0;
         edtSectorCapacidad_Enabled = 0;
         dynSectorId.Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         dynLugarId_Jsonclick = "";
         dynLugarId.Enabled = 1;
         dynEspectaculoId_Jsonclick = "";
         dynEspectaculoId.Enabled = 1;
         edtEventoHoraFecha_Jsonclick = "";
         edtEventoHoraFecha_Enabled = 1;
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

      protected void GXDLALUGARID021( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLALUGARID_data021( ) ;
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

      protected void GXALUGARID_html021( )
      {
         short gxdynajaxvalue;
         GXDLALUGARID_data021( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynLugarId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynLugarId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLALUGARID_data021( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000238 */
         pr_default.execute(36);
         while ( (pr_default.getStatus(36) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000238_A4LugarId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000238_A9LugarNombre[0]);
            pr_default.readNext(36);
         }
         pr_default.close(36);
      }

      protected void GXDLAESPECTACULOID021( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAESPECTACULOID_data021( ) ;
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

      protected void GXAESPECTACULOID_html021( )
      {
         short gxdynajaxvalue;
         GXDLAESPECTACULOID_data021( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynEspectaculoId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynEspectaculoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAESPECTACULOID_data021( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000239 */
         pr_default.execute(37);
         while ( (pr_default.getStatus(37) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000239_A1EspectaculoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000239_A14EspectaculoNombre[0]);
            pr_default.readNext(37);
         }
         pr_default.close(37);
      }

      protected void GX11ASASECTORCUPOACTUAL023( short A5SectorId ,
                                                 short A3EventoId )
      {
         GXt_int1 = A25SectorCupoActual;
         new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
         A25SectorCupoActual = GXt_int1;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridevento_sectores_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_533( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal023( ) ;
            standaloneModal023( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow023( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_533( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridevento_sectoresContainer)) ;
         /* End function gxnrGridevento_sectores_newrow */
      }

      protected void gxnrGridevento_invitaciones_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_665( ) ;
         while ( nGXsfl_66_idx <= nRC_GXsfl_66 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal025( ) ;
            standaloneModal025( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow025( ) ;
            nGXsfl_66_idx = (int)(nGXsfl_66_idx+1);
            sGXsfl_66_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_66_idx), 4, 0), 4, "0");
            SubsflControlProps_665( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridevento_invitacionesContainer)) ;
         /* End function gxnrGridevento_invitaciones_newrow */
      }

      protected void init_web_controls( )
      {
         dynEspectaculoId.Name = "ESPECTACULOID";
         dynEspectaculoId.WebTags = "";
         dynEspectaculoId.removeAllItems();
         /* Using cursor T000240 */
         pr_default.execute(38);
         while ( (pr_default.getStatus(38) != 101) )
         {
            dynEspectaculoId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000240_A1EspectaculoId[0]), 4, 0)), T000240_A14EspectaculoNombre[0], 0);
            pr_default.readNext(38);
         }
         pr_default.close(38);
         if ( dynEspectaculoId.ItemCount > 0 )
         {
            A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynEspectaculoId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1EspectaculoId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         dynLugarId.Name = "LUGARID";
         dynLugarId.WebTags = "";
         dynLugarId.removeAllItems();
         /* Using cursor T000241 */
         pr_default.execute(39);
         while ( (pr_default.getStatus(39) != 101) )
         {
            dynLugarId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000241_A4LugarId[0]), 4, 0)), T000241_A9LugarNombre[0], 0);
            pr_default.readNext(39);
         }
         pr_default.close(39);
         if ( dynLugarId.ItemCount > 0 )
         {
            A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4LugarId), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         GXCCtl = "SECTORID_" + sGXsfl_53_idx;
         dynSectorId.Name = GXCCtl;
         dynSectorId.WebTags = "";
         dynSectorId.removeAllItems();
         /* Using cursor T000242 */
         pr_default.execute(40);
         while ( (pr_default.getStatus(40) != 101) )
         {
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000242_A5SectorId[0]), 4, 0)), T000242_A10SectorNombre[0], 0);
            pr_default.readNext(40);
         }
         pr_default.close(40);
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "INVITACIONNOMINADA_" + sGXsfl_66_idx;
         chkInvitacionNominada.Name = GXCCtl;
         chkInvitacionNominada.WebTags = "";
         chkInvitacionNominada.Caption = "";
         AssignProp("", false, chkInvitacionNominada_Internalname, "TitleCaption", chkInvitacionNominada.Caption, !bGXsfl_66_Refreshing);
         chkInvitacionNominada.CheckedValue = "false";
         A19InvitacionNominada = StringUtil.StrToBool( StringUtil.BoolToStr( A19InvitacionNominada));
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

      public void Valid_Espectaculoid( )
      {
         A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynEspectaculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000243 */
         pr_default.execute(41, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(41) == 101) )
         {
            GX_msglist.addItem("No matching 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = dynEspectaculoId_Internalname;
         }
         pr_default.close(41);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Lugarid( )
      {
         A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynEspectaculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000244 */
         pr_default.execute(42, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = dynLugarId_Internalname;
         }
         pr_default.close(42);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sectorid( )
      {
         A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A4LugarId = (short)(Math.Round(NumberUtil.Val( dynLugarId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         A1EspectaculoId = (short)(Math.Round(NumberUtil.Val( dynEspectaculoId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000227 */
         pr_default.execute(25, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = dynSectorId_Internalname;
         }
         A10SectorNombre = T000227_A10SectorNombre[0];
         A20SectorCapacidad = T000227_A20SectorCapacidad[0];
         A21SectorPrecio = T000227_A21SectorPrecio[0];
         pr_default.close(25);
         GXt_int1 = A25SectorCupoActual;
         new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
         A25SectorCupoActual = GXt_int1;
         dynload_actions( ) ;
         if ( dynSectorId.ItemCount > 0 )
         {
            A5SectorId = (short)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A5SectorId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A10SectorNombre", A10SectorNombre);
         AssignAttri("", false, "A20SectorCapacidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20SectorCapacidad), 4, 0, ".", "")));
         AssignAttri("", false, "A21SectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A21SectorPrecio), 4, 0, ".", "")));
         AssignAttri("", false, "A25SectorCupoActual", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25SectorCupoActual), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV7EventoId","fld":"vEVENTOID","pic":"ZZZ9","hsh":true},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"AV7EventoId","fld":"vEVENTOID","pic":"ZZZ9","hsh":true},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12022","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true},{"av":"AV13TrnContext","fld":"vTRNCONTEXT","hsh":true},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("AFTER TRN",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_EVENTOHORAFECHA","""{"handler":"Valid_Eventohorafecha","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_EVENTOHORAFECHA",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_ESPECTACULOID","""{"handler":"Valid_Espectaculoid","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_ESPECTACULOID",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_LUGARID","""{"handler":"Valid_Lugarid","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_LUGARID",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_SECTORID","""{"handler":"Valid_Sectorid","iparms":[{"av":"dynSectorId"},{"av":"A5SectorId","fld":"SECTORID","pic":"ZZZ9"},{"av":"A3EventoId","fld":"EVENTOID","pic":"ZZZ9"},{"av":"A10SectorNombre","fld":"SECTORNOMBRE"},{"av":"A20SectorCapacidad","fld":"SECTORCAPACIDAD","pic":"ZZZ9"},{"av":"A21SectorPrecio","fld":"SECTORPRECIO","pic":"ZZZ9"},{"av":"A25SectorCupoActual","fld":"SECTORCUPOACTUAL","pic":"ZZZ9"},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_SECTORID",""","oparms":[{"av":"A10SectorNombre","fld":"SECTORNOMBRE"},{"av":"A20SectorCapacidad","fld":"SECTORCAPACIDAD","pic":"ZZZ9"},{"av":"A21SectorPrecio","fld":"SECTORPRECIO","pic":"ZZZ9"},{"av":"A25SectorCupoActual","fld":"SECTORCUPOACTUAL","pic":"ZZZ9"},{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Sectorprecio","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("NULL",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("VALID_INVITACIONID","""{"handler":"Valid_Invitacionid","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("VALID_INVITACIONID",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Invitacionnominada","iparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]""");
         setEventMetadata("NULL",""","oparms":[{"av":"dynLugarId"},{"av":"A4LugarId","fld":"LUGARID","pic":"ZZZ9"},{"av":"dynEspectaculoId"},{"av":"A1EspectaculoId","fld":"ESPECTACULOID","pic":"ZZZ9"}]}""");
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
         pr_default.close(3);
         pr_default.close(25);
         pr_default.close(6);
         pr_default.close(41);
         pr_default.close(42);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z17EventoHoraFecha = (DateTime)(DateTime.MinValue);
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
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         lblTitlesectores_Jsonclick = "";
         lblTitleinvitaciones_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridevento_sectoresContainer = new GXWebGrid( context);
         sMode3 = "";
         sStyleString = "";
         Gridevento_invitacionesContainer = new GXWebGrid( context);
         sMode5 = "";
         AV17Pgmname = "";
         A10SectorNombre = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A18InvitacionNombre = "";
         AV13TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV15WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T000211_A3EventoId = new short[1] ;
         T000211_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         T000211_A1EspectaculoId = new short[1] ;
         T000211_A4LugarId = new short[1] ;
         T00029_A1EspectaculoId = new short[1] ;
         T000210_A4LugarId = new short[1] ;
         T000212_A1EspectaculoId = new short[1] ;
         T000213_A4LugarId = new short[1] ;
         T000214_A3EventoId = new short[1] ;
         T00028_A3EventoId = new short[1] ;
         T00028_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         T00028_A1EspectaculoId = new short[1] ;
         T00028_A4LugarId = new short[1] ;
         T000215_A3EventoId = new short[1] ;
         T000216_A3EventoId = new short[1] ;
         T00027_A3EventoId = new short[1] ;
         T00027_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         T00027_A1EspectaculoId = new short[1] ;
         T00027_A4LugarId = new short[1] ;
         T000217_A3EventoId = new short[1] ;
         T000220_A8VentaId = new short[1] ;
         T000221_A3EventoId = new short[1] ;
         Z10SectorNombre = "";
         T000222_A3EventoId = new short[1] ;
         T000222_A10SectorNombre = new string[] {""} ;
         T000222_A20SectorCapacidad = new short[1] ;
         T000222_A21SectorPrecio = new short[1] ;
         T000222_A5SectorId = new short[1] ;
         T00026_A10SectorNombre = new string[] {""} ;
         T00026_A20SectorCapacidad = new short[1] ;
         T00026_A21SectorPrecio = new short[1] ;
         T000223_A10SectorNombre = new string[] {""} ;
         T000223_A20SectorCapacidad = new short[1] ;
         T000223_A21SectorPrecio = new short[1] ;
         T000224_A3EventoId = new short[1] ;
         T000224_A5SectorId = new short[1] ;
         T00025_A3EventoId = new short[1] ;
         T00025_A5SectorId = new short[1] ;
         T00024_A3EventoId = new short[1] ;
         T00024_A5SectorId = new short[1] ;
         T000227_A10SectorNombre = new string[] {""} ;
         T000227_A20SectorCapacidad = new short[1] ;
         T000227_A21SectorPrecio = new short[1] ;
         T000228_A8VentaId = new short[1] ;
         T000229_A6InvitacionId = new short[1] ;
         T000230_A3EventoId = new short[1] ;
         T000230_A5SectorId = new short[1] ;
         T000231_A6InvitacionId = new short[1] ;
         T000231_A18InvitacionNombre = new string[] {""} ;
         T000231_A19InvitacionNominada = new bool[] {false} ;
         T000232_A6InvitacionId = new short[1] ;
         T00023_A6InvitacionId = new short[1] ;
         T00023_A18InvitacionNombre = new string[] {""} ;
         T00023_A19InvitacionNominada = new bool[] {false} ;
         T00022_A6InvitacionId = new short[1] ;
         T00022_A18InvitacionNombre = new string[] {""} ;
         T00022_A19InvitacionNominada = new bool[] {false} ;
         T000233_A6InvitacionId = new short[1] ;
         T000236_A6InvitacionId = new short[1] ;
         Gridevento_sectoresRow = new GXWebRow();
         subGridevento_sectores_Linesclass = "";
         T000237_A5SectorId = new short[1] ;
         T000237_A10SectorNombre = new string[] {""} ;
         ROClassString = "";
         Gridevento_invitacionesRow = new GXWebRow();
         subGridevento_invitaciones_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridevento_sectoresColumn = new GXWebColumn();
         Gridevento_invitacionesColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000238_A4LugarId = new short[1] ;
         T000238_A9LugarNombre = new string[] {""} ;
         T000239_A1EspectaculoId = new short[1] ;
         T000239_A14EspectaculoNombre = new string[] {""} ;
         T000240_A1EspectaculoId = new short[1] ;
         T000240_A14EspectaculoNombre = new string[] {""} ;
         T000241_A4LugarId = new short[1] ;
         T000241_A9LugarNombre = new string[] {""} ;
         T000242_A5SectorId = new short[1] ;
         T000242_A10SectorNombre = new string[] {""} ;
         T000243_A1EspectaculoId = new short[1] ;
         T000244_A4LugarId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.evento__default(),
            new Object[][] {
                new Object[] {
               T00022_A6InvitacionId, T00022_A18InvitacionNombre, T00022_A19InvitacionNominada
               }
               , new Object[] {
               T00023_A6InvitacionId, T00023_A18InvitacionNombre, T00023_A19InvitacionNominada
               }
               , new Object[] {
               T00024_A3EventoId, T00024_A5SectorId
               }
               , new Object[] {
               T00025_A3EventoId, T00025_A5SectorId
               }
               , new Object[] {
               T00026_A10SectorNombre, T00026_A20SectorCapacidad, T00026_A21SectorPrecio
               }
               , new Object[] {
               T00027_A3EventoId, T00027_A17EventoHoraFecha, T00027_A1EspectaculoId, T00027_A4LugarId
               }
               , new Object[] {
               T00028_A3EventoId, T00028_A17EventoHoraFecha, T00028_A1EspectaculoId, T00028_A4LugarId
               }
               , new Object[] {
               T00029_A1EspectaculoId
               }
               , new Object[] {
               T000210_A4LugarId
               }
               , new Object[] {
               T000211_A3EventoId, T000211_A17EventoHoraFecha, T000211_A1EspectaculoId, T000211_A4LugarId
               }
               , new Object[] {
               T000212_A1EspectaculoId
               }
               , new Object[] {
               T000213_A4LugarId
               }
               , new Object[] {
               T000214_A3EventoId
               }
               , new Object[] {
               T000215_A3EventoId
               }
               , new Object[] {
               T000216_A3EventoId
               }
               , new Object[] {
               T000217_A3EventoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000220_A8VentaId
               }
               , new Object[] {
               T000221_A3EventoId
               }
               , new Object[] {
               T000222_A3EventoId, T000222_A10SectorNombre, T000222_A20SectorCapacidad, T000222_A21SectorPrecio, T000222_A5SectorId
               }
               , new Object[] {
               T000223_A10SectorNombre, T000223_A20SectorCapacidad, T000223_A21SectorPrecio
               }
               , new Object[] {
               T000224_A3EventoId, T000224_A5SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000227_A10SectorNombre, T000227_A20SectorCapacidad, T000227_A21SectorPrecio
               }
               , new Object[] {
               T000228_A8VentaId
               }
               , new Object[] {
               T000229_A6InvitacionId
               }
               , new Object[] {
               T000230_A3EventoId, T000230_A5SectorId
               }
               , new Object[] {
               T000231_A6InvitacionId, T000231_A18InvitacionNombre, T000231_A19InvitacionNominada
               }
               , new Object[] {
               T000232_A6InvitacionId
               }
               , new Object[] {
               T000233_A6InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000236_A6InvitacionId
               }
               , new Object[] {
               T000237_A5SectorId, T000237_A10SectorNombre
               }
               , new Object[] {
               T000238_A4LugarId, T000238_A9LugarNombre
               }
               , new Object[] {
               T000239_A1EspectaculoId, T000239_A14EspectaculoNombre
               }
               , new Object[] {
               T000240_A1EspectaculoId, T000240_A14EspectaculoNombre
               }
               , new Object[] {
               T000241_A4LugarId, T000241_A9LugarNombre
               }
               , new Object[] {
               T000242_A5SectorId, T000242_A10SectorNombre
               }
               , new Object[] {
               T000243_A1EspectaculoId
               }
               , new Object[] {
               T000244_A4LugarId
               }
            }
         );
         Z3EventoId = 0;
         A3EventoId = 0;
         AV17Pgmname = "Evento";
      }

      private short wcpOAV7EventoId ;
      private short Z3EventoId ;
      private short Z1EspectaculoId ;
      private short Z4LugarId ;
      private short N1EspectaculoId ;
      private short N4LugarId ;
      private short Z5SectorId ;
      private short nRcdDeleted_3 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short Z6InvitacionId ;
      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short GxWebError ;
      private short A5SectorId ;
      private short A3EventoId ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short AV7EventoId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short nBlankRcdCount3 ;
      private short RcdFound3 ;
      private short nBlankRcdUsr3 ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short AV8Insert_EspectaculoId ;
      private short AV9Insert_LugarId ;
      private short RcdFound2 ;
      private short A6InvitacionId ;
      private short A20SectorCapacidad ;
      private short A25SectorCupoActual ;
      private short A21SectorPrecio ;
      private short Gx_BScreen ;
      private short Z20SectorCapacidad ;
      private short Z21SectorPrecio ;
      private short nIsDirty_3 ;
      private short nIsDirty_5 ;
      private short subGridevento_sectores_Backcolorstyle ;
      private short subGridevento_sectores_Backstyle ;
      private short subGridevento_invitaciones_Backcolorstyle ;
      private short subGridevento_invitaciones_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridevento_sectores_Allowselection ;
      private short subGridevento_sectores_Allowhovering ;
      private short subGridevento_sectores_Allowcollapsing ;
      private short subGridevento_sectores_Collapsed ;
      private short subGridevento_invitaciones_Allowselection ;
      private short subGridevento_invitaciones_Allowhovering ;
      private short subGridevento_invitaciones_Allowcollapsing ;
      private short subGridevento_invitaciones_Collapsed ;
      private short GXt_int1 ;
      private short Z25SectorCupoActual ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int nRC_GXsfl_66 ;
      private int nGXsfl_66_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEventoHoraFecha_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtSectorCapacidad_Enabled ;
      private int edtSectorCupoActual_Enabled ;
      private int edtSectorPrecio_Enabled ;
      private int fRowAdded ;
      private int edtInvitacionId_Enabled ;
      private int edtInvitacionNombre_Enabled ;
      private int AV18GXV1 ;
      private int subGridevento_sectores_Backcolor ;
      private int subGridevento_sectores_Allbackcolor ;
      private int subGridevento_invitaciones_Backcolor ;
      private int subGridevento_invitaciones_Allbackcolor ;
      private int defedtInvitacionId_Enabled ;
      private int defdynSectorId_Enabled ;
      private int idxLst ;
      private int subGridevento_sectores_Selectedindex ;
      private int subGridevento_sectores_Selectioncolor ;
      private int subGridevento_sectores_Hoveringcolor ;
      private int subGridevento_invitaciones_Selectedindex ;
      private int subGridevento_invitaciones_Selectioncolor ;
      private int subGridevento_invitaciones_Hoveringcolor ;
      private int gxdynajaxindex ;
      private long GRIDEVENTO_SECTORES_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEventoHoraFecha_Internalname ;
      private string sGXsfl_53_idx="0001" ;
      private string sGXsfl_66_idx="0001" ;
      private string dynEspectaculoId_Internalname ;
      private string dynLugarId_Internalname ;
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
      private string edtEventoHoraFecha_Jsonclick ;
      private string dynEspectaculoId_Jsonclick ;
      private string dynLugarId_Jsonclick ;
      private string divSectorestable_Internalname ;
      private string lblTitlesectores_Internalname ;
      private string lblTitlesectores_Jsonclick ;
      private string divInvitacionestable_Internalname ;
      private string lblTitleinvitaciones_Internalname ;
      private string lblTitleinvitaciones_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode3 ;
      private string dynSectorId_Internalname ;
      private string edtSectorCapacidad_Internalname ;
      private string edtSectorCupoActual_Internalname ;
      private string edtSectorPrecio_Internalname ;
      private string sStyleString ;
      private string subGridevento_sectores_Internalname ;
      private string sMode5 ;
      private string edtInvitacionId_Internalname ;
      private string edtInvitacionNombre_Internalname ;
      private string chkInvitacionNominada_Internalname ;
      private string subGridevento_invitaciones_Internalname ;
      private string AV17Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridevento_sectores_Class ;
      private string subGridevento_sectores_Linesclass ;
      private string dynSectorId_Jsonclick ;
      private string ROClassString ;
      private string edtSectorCapacidad_Jsonclick ;
      private string edtSectorCupoActual_Jsonclick ;
      private string edtSectorPrecio_Jsonclick ;
      private string sGXsfl_66_fel_idx="0001" ;
      private string subGridevento_invitaciones_Class ;
      private string subGridevento_invitaciones_Linesclass ;
      private string edtInvitacionId_Jsonclick ;
      private string edtInvitacionNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridevento_sectores_Header ;
      private string subGridevento_invitaciones_Header ;
      private string gxwrpcisep ;
      private DateTime Z17EventoHoraFecha ;
      private DateTime A17EventoHoraFecha ;
      private bool Z19InvitacionNominada ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool bGXsfl_66_Refreshing=false ;
      private bool A19InvitacionNominada ;
      private bool returnInSub ;
      private bool gxdyncontrolsrefreshing ;
      private string Z18InvitacionNombre ;
      private string A10SectorNombre ;
      private string A18InvitacionNombre ;
      private string Z10SectorNombre ;
      private IGxSession AV15WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridevento_sectoresContainer ;
      private GXWebGrid Gridevento_invitacionesContainer ;
      private GXWebRow Gridevento_sectoresRow ;
      private GXWebRow Gridevento_invitacionesRow ;
      private GXWebColumn Gridevento_sectoresColumn ;
      private GXWebColumn Gridevento_invitacionesColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynEspectaculoId ;
      private GXCombobox dynLugarId ;
      private GXCombobox dynSectorId ;
      private GXCheckbox chkInvitacionNominada ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV13TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T000211_A3EventoId ;
      private DateTime[] T000211_A17EventoHoraFecha ;
      private short[] T000211_A1EspectaculoId ;
      private short[] T000211_A4LugarId ;
      private short[] T00029_A1EspectaculoId ;
      private short[] T000210_A4LugarId ;
      private short[] T000212_A1EspectaculoId ;
      private short[] T000213_A4LugarId ;
      private short[] T000214_A3EventoId ;
      private short[] T00028_A3EventoId ;
      private DateTime[] T00028_A17EventoHoraFecha ;
      private short[] T00028_A1EspectaculoId ;
      private short[] T00028_A4LugarId ;
      private short[] T000215_A3EventoId ;
      private short[] T000216_A3EventoId ;
      private short[] T00027_A3EventoId ;
      private DateTime[] T00027_A17EventoHoraFecha ;
      private short[] T00027_A1EspectaculoId ;
      private short[] T00027_A4LugarId ;
      private short[] T000217_A3EventoId ;
      private short[] T000220_A8VentaId ;
      private short[] T000221_A3EventoId ;
      private short[] T000222_A3EventoId ;
      private string[] T000222_A10SectorNombre ;
      private short[] T000222_A20SectorCapacidad ;
      private short[] T000222_A21SectorPrecio ;
      private short[] T000222_A5SectorId ;
      private string[] T00026_A10SectorNombre ;
      private short[] T00026_A20SectorCapacidad ;
      private short[] T00026_A21SectorPrecio ;
      private string[] T000223_A10SectorNombre ;
      private short[] T000223_A20SectorCapacidad ;
      private short[] T000223_A21SectorPrecio ;
      private short[] T000224_A3EventoId ;
      private short[] T000224_A5SectorId ;
      private short[] T00025_A3EventoId ;
      private short[] T00025_A5SectorId ;
      private short[] T00024_A3EventoId ;
      private short[] T00024_A5SectorId ;
      private string[] T000227_A10SectorNombre ;
      private short[] T000227_A20SectorCapacidad ;
      private short[] T000227_A21SectorPrecio ;
      private short[] T000228_A8VentaId ;
      private short[] T000229_A6InvitacionId ;
      private short[] T000230_A3EventoId ;
      private short[] T000230_A5SectorId ;
      private short[] T000231_A6InvitacionId ;
      private string[] T000231_A18InvitacionNombre ;
      private bool[] T000231_A19InvitacionNominada ;
      private short[] T000232_A6InvitacionId ;
      private short[] T00023_A6InvitacionId ;
      private string[] T00023_A18InvitacionNombre ;
      private bool[] T00023_A19InvitacionNominada ;
      private short[] T00022_A6InvitacionId ;
      private string[] T00022_A18InvitacionNombre ;
      private bool[] T00022_A19InvitacionNominada ;
      private short[] T000233_A6InvitacionId ;
      private short[] T000236_A6InvitacionId ;
      private short[] T000237_A5SectorId ;
      private string[] T000237_A10SectorNombre ;
      private short[] T000238_A4LugarId ;
      private string[] T000238_A9LugarNombre ;
      private short[] T000239_A1EspectaculoId ;
      private string[] T000239_A14EspectaculoNombre ;
      private short[] T000240_A1EspectaculoId ;
      private string[] T000240_A14EspectaculoNombre ;
      private short[] T000241_A4LugarId ;
      private string[] T000241_A9LugarNombre ;
      private short[] T000242_A5SectorId ;
      private string[] T000242_A10SectorNombre ;
      private short[] T000243_A1EspectaculoId ;
      private short[] T000244_A4LugarId ;
   }

   public class evento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new UpdateCursor(def[32])
         ,new UpdateCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@EventoHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@EventoHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000228;
          prmT000228 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000229;
          prmT000229 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmT000231;
          prmT000231 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000232;
          prmT000232 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000233;
          prmT000233 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0)
          };
          Object[] prmT000234;
          prmT000234 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000235;
          prmT000235 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000236;
          prmT000236 = new Object[] {
          };
          Object[] prmT000237;
          prmT000237 = new Object[] {
          };
          Object[] prmT000238;
          prmT000238 = new Object[] {
          };
          Object[] prmT000239;
          prmT000239 = new Object[] {
          };
          Object[] prmT000240;
          prmT000240 = new Object[] {
          };
          Object[] prmT000241;
          prmT000241 = new Object[] {
          };
          Object[] prmT000242;
          prmT000242 = new Object[] {
          };
          Object[] prmT000243;
          prmT000243 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000244;
          prmT000244 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [EventoId], [SectorId] FROM [EventoSector] WITH (UPDLOCK) WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [EventoId], [SectorId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [EventoId], [EventoHoraFecha], [EspectaculoId], [LugarId] FROM [Evento] WITH (UPDLOCK) WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [EventoId], [EventoHoraFecha], [EspectaculoId], [LugarId] FROM [Evento] WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT TM1.[EventoId], TM1.[EventoHoraFecha], TM1.[EspectaculoId], TM1.[LugarId] FROM [Evento] TM1 WHERE TM1.[EventoId] = @EventoId ORDER BY TM1.[EventoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000214", "SELECT [EventoId] FROM [Evento] WHERE [EventoId] = @EventoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000215", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE ( [EventoId] > @EventoId) ORDER BY [EventoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE ( [EventoId] < @EventoId) ORDER BY [EventoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000217", "INSERT INTO [Evento]([EventoHoraFecha], [EspectaculoId], [LugarId]) VALUES(@EventoHoraFecha, @EspectaculoId, @LugarId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000218", "UPDATE [Evento] SET [EventoHoraFecha]=@EventoHoraFecha, [EspectaculoId]=@EspectaculoId, [LugarId]=@LugarId  WHERE [EventoId] = @EventoId", GxErrorMask.GX_NOMASK,prmT000218)
             ,new CursorDef("T000219", "DELETE FROM [Evento]  WHERE [EventoId] = @EventoId", GxErrorMask.GX_NOMASK,prmT000219)
             ,new CursorDef("T000220", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000221", "SELECT [EventoId] FROM [Evento] ORDER BY [EventoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT T1.[EventoId], T2.[SectorNombre], T2.[SectorCapacidad], T2.[SectorPrecio], T1.[SectorId] FROM ([EventoSector] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) WHERE T1.[EventoId] = @EventoId and T1.[SectorId] = @SectorId ORDER BY T1.[EventoId], T1.[SectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000223", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000224", "SELECT [EventoId], [SectorId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000225", "INSERT INTO [EventoSector]([EventoId], [SectorId]) VALUES(@EventoId, @SectorId)", GxErrorMask.GX_NOMASK,prmT000225)
             ,new CursorDef("T000226", "DELETE FROM [EventoSector]  WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000226)
             ,new CursorDef("T000227", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000227,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000228", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000228,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000229", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000229,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000230", "SELECT [EventoId], [SectorId] FROM [EventoSector] WHERE [EventoId] = @EventoId ORDER BY [EventoId], [SectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000231", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ORDER BY [InvitacionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000231,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000232", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000232,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000233", "INSERT INTO [Invitacion]([InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId]) VALUES(@InvitacionNombre, @InvitacionNominada, convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000233,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000234", "UPDATE [Invitacion] SET [InvitacionNombre]=@InvitacionNombre, [InvitacionNominada]=@InvitacionNominada  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000234)
             ,new CursorDef("T000235", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000235)
             ,new CursorDef("T000236", "SELECT [InvitacionId] FROM [Invitacion] ORDER BY [InvitacionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000236,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000237", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000237,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000238", "SELECT [LugarId], [LugarNombre] FROM [Lugar] ORDER BY [LugarNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000238,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000239", "SELECT [EspectaculoId], [EspectaculoNombre] FROM [Espectaculo] ORDER BY [EspectaculoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000239,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000240", "SELECT [EspectaculoId], [EspectaculoNombre] FROM [Espectaculo] ORDER BY [EspectaculoNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000240,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000241", "SELECT [LugarId], [LugarNombre] FROM [Lugar] ORDER BY [LugarNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000241,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000242", "SELECT [SectorId], [SectorNombre] FROM [Sector] ORDER BY [SectorNombre] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000242,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000243", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000243,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000244", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000244,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 28 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 36 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 37 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 38 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 41 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 42 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
