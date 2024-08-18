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
   public class evento_bc : GxSilentTrn, IGxSilentTrn
   {
      public evento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public evento_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
         Gx_mode = "INS";
         return  ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z3EventoId = A3EventoId;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
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
               if ( AnyError == 0 )
               {
                  ZM022( 4) ;
                  ZM022( 5) ;
               }
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
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
         }
      }

      protected void CONFIRM_025( )
      {
         nGXsfl_5_idx = 0;
         while ( nGXsfl_5_idx < bcEvento.gxTpr_Invitaciones.Count )
         {
            ReadRow025( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound5 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_5 != 0 ) )
            {
               GetKey025( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate025( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable025( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors025( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
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
                           BeforeValidate025( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable025( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors025( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow5( ((SdtEvento_Invitaciones)bcEvento.gxTpr_Invitaciones.Item(nGXsfl_5_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_023( )
      {
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcEvento.gxTpr_Sectores.Count )
         {
            ReadRow023( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               GetKey023( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate023( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable023( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM023( 7) ;
                        }
                        CloseExtendedTableCursors023( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound3 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
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
                           BeforeValidate023( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable023( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM023( 7) ;
                              }
                              CloseExtendedTableCursors023( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow3( ((SdtEvento_Sectores)bcEvento.gxTpr_Sectores.Item(nGXsfl_3_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z17EventoHoraFecha = A17EventoHoraFecha;
            Z1EspectaculoId = A1EspectaculoId;
            Z4LugarId = A4LugarId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z3EventoId = A3EventoId;
            Z17EventoHoraFecha = A17EventoHoraFecha;
            Z1EspectaculoId = A1EspectaculoId;
            Z4LugarId = A4LugarId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC000211 */
         pr_default.execute(9, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A17EventoHoraFecha = BC000211_A17EventoHoraFecha[0];
            A1EspectaculoId = BC000211_A1EspectaculoId[0];
            A4LugarId = BC000211_A4LugarId[0];
            ZM022( -3) ;
         }
         pr_default.close(9);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A17EventoHoraFecha) || ( A17EventoHoraFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Field Evento Hora Fecha is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00029 */
         pr_default.execute(7, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         pr_default.close(7);
         /* Using cursor BC000210 */
         pr_default.execute(8, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
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

      protected void GetKey022( )
      {
         /* Using cursor BC000212 */
         pr_default.execute(10, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00028 */
         pr_default.execute(6, new Object[] {A3EventoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM022( 3) ;
            RcdFound2 = 1;
            A3EventoId = BC00028_A3EventoId[0];
            A17EventoHoraFecha = BC00028_A17EventoHoraFecha[0];
            A1EspectaculoId = BC00028_A1EspectaculoId[0];
            A4LugarId = BC00028_A4LugarId[0];
            Z3EventoId = A3EventoId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00027 */
            pr_default.execute(5, new Object[] {A3EventoId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Evento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( Z17EventoHoraFecha != BC00027_A17EventoHoraFecha[0] ) || ( Z1EspectaculoId != BC00027_A1EspectaculoId[0] ) || ( Z4LugarId != BC00027_A4LugarId[0] ) )
            {
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
                     /* Using cursor BC000213 */
                     pr_default.execute(11, new Object[] {A17EventoHoraFecha, A1EspectaculoId, A4LugarId});
                     A3EventoId = BC000213_A3EventoId[0];
                     pr_default.close(11);
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
                     /* Using cursor BC000214 */
                     pr_default.execute(12, new Object[] {A17EventoHoraFecha, A1EspectaculoId, A4LugarId, A3EventoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Evento");
                     if ( (pr_default.getStatus(12) == 103) )
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
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
         Gx_mode = "DLT";
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
                  ScanKeyStart023( ) ;
                  while ( RcdFound3 != 0 )
                  {
                     getByPrimaryKey023( ) ;
                     Delete023( ) ;
                     ScanKeyNext023( ) ;
                  }
                  ScanKeyEnd023( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000215 */
                     pr_default.execute(13, new Object[] {A3EventoId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Evento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
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
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000216 */
            pr_default.execute(14, new Object[] {A3EventoId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel023( )
      {
         nGXsfl_3_idx = 0;
         while ( nGXsfl_3_idx < bcEvento.gxTpr_Sectores.Count )
         {
            ReadRow023( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound3 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_3 != 0 ) )
            {
               standaloneNotModal023( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert023( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete023( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update023( ) ;
                  }
               }
            }
            KeyVarsToRow3( ((SdtEvento_Sectores)bcEvento.gxTpr_Sectores.Item(nGXsfl_3_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_3_idx = 0;
            while ( nGXsfl_3_idx < bcEvento.gxTpr_Sectores.Count )
            {
               ReadRow023( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound3 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcEvento.gxTpr_Sectores.RemoveElement(nGXsfl_3_idx);
                  nGXsfl_3_idx = (int)(nGXsfl_3_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey023( ) ;
                  VarsToRow3( ((SdtEvento_Sectores)bcEvento.gxTpr_Sectores.Item(nGXsfl_3_idx))) ;
               }
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
      }

      protected void ProcessNestedLevel025( )
      {
         nGXsfl_5_idx = 0;
         while ( nGXsfl_5_idx < bcEvento.gxTpr_Invitaciones.Count )
         {
            ReadRow025( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound5 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal025( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert025( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete025( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update025( ) ;
                  }
               }
            }
            KeyVarsToRow5( ((SdtEvento_Invitaciones)bcEvento.gxTpr_Invitaciones.Item(nGXsfl_5_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_5_idx = 0;
            while ( nGXsfl_5_idx < bcEvento.gxTpr_Invitaciones.Count )
            {
               ReadRow025( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcEvento.gxTpr_Invitaciones.RemoveElement(nGXsfl_5_idx);
                  nGXsfl_5_idx = (int)(nGXsfl_5_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey025( ) ;
                  VarsToRow5( ((SdtEvento_Invitaciones)bcEvento.gxTpr_Invitaciones.Item(nGXsfl_5_idx))) ;
               }
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
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000217 */
         pr_default.execute(15, new Object[] {A3EventoId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3EventoId = BC000217_A3EventoId[0];
            A17EventoHoraFecha = BC000217_A17EventoHoraFecha[0];
            A1EspectaculoId = BC000217_A1EspectaculoId[0];
            A4LugarId = BC000217_A4LugarId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound2 = 1;
            A3EventoId = BC000217_A3EventoId[0];
            A17EventoHoraFecha = BC000217_A17EventoHoraFecha[0];
            A1EspectaculoId = BC000217_A1EspectaculoId[0];
            A4LugarId = BC000217_A4LugarId[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(15);
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
      }

      protected void ZM023( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z25SectorCupoActual = A25SectorCupoActual;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z10SectorNombre = A10SectorNombre;
            Z20SectorCapacidad = A20SectorCapacidad;
            Z21SectorPrecio = A21SectorPrecio;
            Z25SectorCupoActual = A25SectorCupoActual;
         }
         if ( GX_JID == -6 )
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
      }

      protected void Load023( )
      {
         /* Using cursor BC000218 */
         pr_default.execute(16, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound3 = 1;
            A10SectorNombre = BC000218_A10SectorNombre[0];
            A20SectorCapacidad = BC000218_A20SectorCapacidad[0];
            A21SectorPrecio = BC000218_A21SectorPrecio[0];
            ZM023( -6) ;
         }
         pr_default.close(16);
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
         Gx_BScreen = 1;
         standaloneModal023( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A5SectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
         }
         A10SectorNombre = BC00026_A10SectorNombre[0];
         A20SectorCapacidad = BC00026_A20SectorCapacidad[0];
         A21SectorPrecio = BC00026_A21SectorPrecio[0];
         pr_default.close(4);
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

      protected void GetKey023( )
      {
         /* Using cursor BC000219 */
         pr_default.execute(17, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey023( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(3) != 101) && ( BC00025_A3EventoId[0] == A3EventoId ) )
         {
            ZM023( 6) ;
            RcdFound3 = 1;
            InitializeNonKey023( ) ;
            A5SectorId = BC00025_A5SectorId[0];
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal023( ) ;
            Load023( ) ;
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey023( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal023( ) ;
            Gx_mode = sMode3;
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
            /* Using cursor BC00024 */
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
                     /* Using cursor BC000220 */
                     pr_default.execute(18, new Object[] {A3EventoId, A5SectorId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("EventoSector");
                     if ( (pr_default.getStatus(18) == 1) )
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
         CloseExtendedTableCursors023( ) ;
      }

      protected void DeferredUpdate023( )
      {
      }

      protected void Delete023( )
      {
         Gx_mode = "DLT";
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
                  /* Using cursor BC000221 */
                  pr_default.execute(19, new Object[] {A3EventoId, A5SectorId});
                  pr_default.close(19);
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
         EndLevel023( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls023( )
      {
         standaloneModal023( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000222 */
            pr_default.execute(20, new Object[] {A5SectorId});
            A10SectorNombre = BC000222_A10SectorNombre[0];
            A20SectorCapacidad = BC000222_A20SectorCapacidad[0];
            A21SectorPrecio = BC000222_A21SectorPrecio[0];
            pr_default.close(20);
            GXt_int1 = A25SectorCupoActual;
            new calcularcupoactual(context ).execute(  A5SectorId,  A3EventoId, out  GXt_int1) ;
            A25SectorCupoActual = GXt_int1;
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000223 */
            pr_default.execute(21, new Object[] {A3EventoId, A5SectorId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC000224 */
            pr_default.execute(22, new Object[] {A3EventoId, A5SectorId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
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

      public void ScanKeyStart023( )
      {
         /* Scan By routine */
         /* Using cursor BC000225 */
         pr_default.execute(23, new Object[] {A3EventoId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound3 = 1;
            A10SectorNombre = BC000225_A10SectorNombre[0];
            A20SectorCapacidad = BC000225_A20SectorCapacidad[0];
            A21SectorPrecio = BC000225_A21SectorPrecio[0];
            A5SectorId = BC000225_A5SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext023( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound3 = 0;
         ScanKeyLoad023( ) ;
      }

      protected void ScanKeyLoad023( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound3 = 1;
            A10SectorNombre = BC000225_A10SectorNombre[0];
            A20SectorCapacidad = BC000225_A20SectorCapacidad[0];
            A21SectorPrecio = BC000225_A21SectorPrecio[0];
            A5SectorId = BC000225_A5SectorId[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd023( )
      {
         pr_default.close(23);
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
      }

      protected void send_integrity_lvl_hashes023( )
      {
      }

      protected void ZM025( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z18InvitacionNombre = A18InvitacionNombre;
            Z19InvitacionNominada = A19InvitacionNominada;
         }
         if ( GX_JID == -8 )
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
      }

      protected void Load025( )
      {
         /* Using cursor BC000226 */
         pr_default.execute(24, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound5 = 1;
            A18InvitacionNombre = BC000226_A18InvitacionNombre[0];
            A19InvitacionNominada = BC000226_A19InvitacionNominada[0];
            ZM025( -8) ;
         }
         pr_default.close(24);
         OnLoadActions025( ) ;
      }

      protected void OnLoadActions025( )
      {
      }

      protected void CheckExtendedTable025( )
      {
         Gx_BScreen = 1;
         standaloneModal025( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors025( )
      {
      }

      protected void enableDisable025( )
      {
      }

      protected void GetKey025( )
      {
         /* Using cursor BC000227 */
         pr_default.execute(25, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey025( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A6InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM025( 8) ;
            RcdFound5 = 1;
            InitializeNonKey025( ) ;
            A6InvitacionId = BC00023_A6InvitacionId[0];
            A18InvitacionNombre = BC00023_A18InvitacionNombre[0];
            A19InvitacionNominada = BC00023_A19InvitacionNominada[0];
            Z6InvitacionId = A6InvitacionId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal025( ) ;
            Load025( ) ;
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey025( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal025( ) ;
            Gx_mode = sMode5;
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
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A6InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18InvitacionNombre, BC00022_A18InvitacionNombre[0]) != 0 ) || ( Z19InvitacionNominada != BC00022_A19InvitacionNominada[0] ) )
            {
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
                     /* Using cursor BC000228 */
                     pr_default.execute(26, new Object[] {A18InvitacionNombre, A19InvitacionNominada});
                     A6InvitacionId = BC000228_A6InvitacionId[0];
                     pr_default.close(26);
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
                     /* Using cursor BC000229 */
                     pr_default.execute(27, new Object[] {A18InvitacionNombre, A19InvitacionNominada, A6InvitacionId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(27) == 103) )
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
         CloseExtendedTableCursors025( ) ;
      }

      protected void DeferredUpdate025( )
      {
      }

      protected void Delete025( )
      {
         Gx_mode = "DLT";
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
                  /* Using cursor BC000230 */
                  pr_default.execute(28, new Object[] {A6InvitacionId});
                  pr_default.close(28);
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
         EndLevel025( ) ;
         Gx_mode = sMode5;
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

      public void ScanKeyStart025( )
      {
         /* Scan By routine */
         /* Using cursor BC000231 */
         pr_default.execute(29);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = BC000231_A6InvitacionId[0];
            A18InvitacionNombre = BC000231_A18InvitacionNombre[0];
            A19InvitacionNominada = BC000231_A19InvitacionNominada[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext025( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound5 = 0;
         ScanKeyLoad025( ) ;
      }

      protected void ScanKeyLoad025( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound5 = 1;
            A6InvitacionId = BC000231_A6InvitacionId[0];
            A18InvitacionNombre = BC000231_A18InvitacionNombre[0];
            A19InvitacionNominada = BC000231_A19InvitacionNominada[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd025( )
      {
         pr_default.close(29);
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
      }

      protected void send_integrity_lvl_hashes025( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcEvento) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcEvento, 1) ;
      }

      protected void AddRow023( )
      {
         SdtEvento_Sectores obj3;
         obj3 = new SdtEvento_Sectores(context);
         VarsToRow3( obj3) ;
         bcEvento.gxTpr_Sectores.Add(obj3, 0);
         obj3.gxTpr_Mode = "UPD";
         obj3.gxTpr_Modified = 0;
      }

      protected void ReadRow023( )
      {
         nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
         RowToVars3( ((SdtEvento_Sectores)bcEvento.gxTpr_Sectores.Item(nGXsfl_3_idx)), 1) ;
      }

      protected void AddRow025( )
      {
         SdtEvento_Invitaciones obj5;
         obj5 = new SdtEvento_Invitaciones(context);
         VarsToRow5( obj5) ;
         bcEvento.gxTpr_Invitaciones.Add(obj5, 0);
         obj5.gxTpr_Mode = "UPD";
         obj5.gxTpr_Modified = 0;
      }

      protected void ReadRow025( )
      {
         nGXsfl_5_idx = (int)(nGXsfl_5_idx+1);
         RowToVars5( ((SdtEvento_Invitaciones)bcEvento.gxTpr_Invitaciones.Item(nGXsfl_5_idx)), 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         A1EspectaculoId = 0;
         A4LugarId = 0;
         Z17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         Z1EspectaculoId = 0;
         Z4LugarId = 0;
      }

      protected void InitAll022( )
      {
         A3EventoId = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey023( )
      {
         A25SectorCupoActual = 0;
         A10SectorNombre = "";
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

      public void VarsToRow2( SdtEvento obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Eventohorafecha = A17EventoHoraFecha;
         obj2.gxTpr_Espectaculoid = A1EspectaculoId;
         obj2.gxTpr_Lugarid = A4LugarId;
         obj2.gxTpr_Eventoid = A3EventoId;
         obj2.gxTpr_Eventoid_Z = Z3EventoId;
         obj2.gxTpr_Eventohorafecha_Z = Z17EventoHoraFecha;
         obj2.gxTpr_Espectaculoid_Z = Z1EspectaculoId;
         obj2.gxTpr_Lugarid_Z = Z4LugarId;
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtEvento obj2 )
      {
         obj2.gxTpr_Eventoid = A3EventoId;
         return  ;
      }

      public void RowToVars2( SdtEvento obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A17EventoHoraFecha = obj2.gxTpr_Eventohorafecha;
         A1EspectaculoId = obj2.gxTpr_Espectaculoid;
         A4LugarId = obj2.gxTpr_Lugarid;
         A3EventoId = obj2.gxTpr_Eventoid;
         Z3EventoId = obj2.gxTpr_Eventoid_Z;
         Z17EventoHoraFecha = obj2.gxTpr_Eventohorafecha_Z;
         Z1EspectaculoId = obj2.gxTpr_Espectaculoid_Z;
         Z4LugarId = obj2.gxTpr_Lugarid_Z;
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow3( SdtEvento_Sectores obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Sectorcupoactual = A25SectorCupoActual;
         obj3.gxTpr_Sectornombre = A10SectorNombre;
         obj3.gxTpr_Sectorcapacidad = A20SectorCapacidad;
         obj3.gxTpr_Sectorprecio = A21SectorPrecio;
         obj3.gxTpr_Sectorid = A5SectorId;
         obj3.gxTpr_Sectorid_Z = Z5SectorId;
         obj3.gxTpr_Sectornombre_Z = Z10SectorNombre;
         obj3.gxTpr_Sectorcapacidad_Z = Z20SectorCapacidad;
         obj3.gxTpr_Sectorprecio_Z = Z21SectorPrecio;
         obj3.gxTpr_Sectorcupoactual_Z = Z25SectorCupoActual;
         obj3.gxTpr_Modified = nIsMod_3;
         return  ;
      }

      public void KeyVarsToRow3( SdtEvento_Sectores obj3 )
      {
         obj3.gxTpr_Sectorid = A5SectorId;
         return  ;
      }

      public void RowToVars3( SdtEvento_Sectores obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A25SectorCupoActual = obj3.gxTpr_Sectorcupoactual;
         A10SectorNombre = obj3.gxTpr_Sectornombre;
         A20SectorCapacidad = obj3.gxTpr_Sectorcapacidad;
         A21SectorPrecio = obj3.gxTpr_Sectorprecio;
         A5SectorId = obj3.gxTpr_Sectorid;
         Z5SectorId = obj3.gxTpr_Sectorid_Z;
         Z10SectorNombre = obj3.gxTpr_Sectornombre_Z;
         Z20SectorCapacidad = obj3.gxTpr_Sectorcapacidad_Z;
         Z21SectorPrecio = obj3.gxTpr_Sectorprecio_Z;
         Z25SectorCupoActual = obj3.gxTpr_Sectorcupoactual_Z;
         nIsMod_3 = obj3.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow5( SdtEvento_Invitaciones obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Invitacionnombre = A18InvitacionNombre;
         obj5.gxTpr_Invitacionnominada = A19InvitacionNominada;
         obj5.gxTpr_Invitacionid = A6InvitacionId;
         obj5.gxTpr_Invitacionid_Z = Z6InvitacionId;
         obj5.gxTpr_Invitacionnombre_Z = Z18InvitacionNombre;
         obj5.gxTpr_Invitacionnominada_Z = Z19InvitacionNominada;
         obj5.gxTpr_Modified = nIsMod_5;
         return  ;
      }

      public void KeyVarsToRow5( SdtEvento_Invitaciones obj5 )
      {
         obj5.gxTpr_Invitacionid = A6InvitacionId;
         return  ;
      }

      public void RowToVars5( SdtEvento_Invitaciones obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A18InvitacionNombre = obj5.gxTpr_Invitacionnombre;
         A19InvitacionNominada = obj5.gxTpr_Invitacionnominada;
         A6InvitacionId = obj5.gxTpr_Invitacionid;
         Z6InvitacionId = obj5.gxTpr_Invitacionid_Z;
         Z18InvitacionNombre = obj5.gxTpr_Invitacionnombre_Z;
         Z19InvitacionNominada = obj5.gxTpr_Invitacionnominada_Z;
         nIsMod_5 = obj5.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A3EventoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3EventoId = A3EventoId;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcEvento.gxTpr_Sectores.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart023( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               Z3EventoId = A3EventoId;
               Z5SectorId = A5SectorId;
               ZM023( -6) ;
               OnLoadActions023( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               AddRow023( ) ;
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext023( ) ;
            }
            ScanKeyEnd023( ) ;
         }
         bcEvento.gxTpr_Invitaciones.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart025( ) ;
            nGXsfl_5_idx = 1;
            while ( RcdFound5 != 0 )
            {
               Z6InvitacionId = A6InvitacionId;
               ZM025( -8) ;
               OnLoadActions025( ) ;
               nRcdExists_5 = 1;
               nIsMod_5 = 0;
               AddRow025( ) ;
               nGXsfl_5_idx = (int)(nGXsfl_5_idx+1);
               ScanKeyNext025( ) ;
            }
            ScanKeyEnd025( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars2( bcEvento, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3EventoId = A3EventoId;
         }
         ZM022( -3) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcEvento.gxTpr_Sectores.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart023( ) ;
            nGXsfl_3_idx = 1;
            while ( RcdFound3 != 0 )
            {
               Z3EventoId = A3EventoId;
               Z5SectorId = A5SectorId;
               ZM023( -6) ;
               OnLoadActions023( ) ;
               nRcdExists_3 = 1;
               nIsMod_3 = 0;
               AddRow023( ) ;
               nGXsfl_3_idx = (int)(nGXsfl_3_idx+1);
               ScanKeyNext023( ) ;
            }
            ScanKeyEnd023( ) ;
         }
         bcEvento.gxTpr_Invitaciones.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart025( ) ;
            nGXsfl_5_idx = 1;
            while ( RcdFound5 != 0 )
            {
               Z6InvitacionId = A6InvitacionId;
               ZM025( -8) ;
               OnLoadActions025( ) ;
               nRcdExists_5 = 1;
               nIsMod_5 = 0;
               AddRow025( ) ;
               nGXsfl_5_idx = (int)(nGXsfl_5_idx+1);
               ScanKeyNext025( ) ;
            }
            ScanKeyEnd025( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3EventoId != Z3EventoId )
               {
                  A3EventoId = Z3EventoId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update022( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A3EventoId != Z3EventoId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
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
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcEvento, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcEvento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcEvento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcEvento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bcEvento) ;
         }
         else
         {
            SdtEvento auxBC = new SdtEvento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A3EventoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEvento);
               auxBC.Save();
               bcEvento.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcEvento, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcEvento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow2( bcEvento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bcEvento) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcEvento, 0) ;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A3EventoId != Z3EventoId )
            {
               A3EventoId = Z3EventoId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A3EventoId != Z3EventoId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(6);
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(20);
         context.RollbackDataStores("evento_bc",pr_default);
         VarsToRow2( bcEvento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcEvento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEvento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEvento )
         {
            bcEvento = (SdtEvento)(sdt);
            if ( StringUtil.StrCmp(bcEvento.gxTpr_Mode, "") == 0 )
            {
               bcEvento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcEvento) ;
            }
            else
            {
               RowToVars2( bcEvento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEvento.gxTpr_Mode, "") == 0 )
            {
               bcEvento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcEvento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEvento Evento_BC
      {
         get {
            return bcEvento ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         pr_default.close(20);
         pr_default.close(6);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode2 = "";
         Z17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         A17EventoHoraFecha = (DateTime)(DateTime.MinValue);
         BC000211_A3EventoId = new short[1] ;
         BC000211_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC000211_A1EspectaculoId = new short[1] ;
         BC000211_A4LugarId = new short[1] ;
         BC00029_A1EspectaculoId = new short[1] ;
         BC000210_A4LugarId = new short[1] ;
         BC000212_A3EventoId = new short[1] ;
         BC00028_A3EventoId = new short[1] ;
         BC00028_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC00028_A1EspectaculoId = new short[1] ;
         BC00028_A4LugarId = new short[1] ;
         BC00027_A3EventoId = new short[1] ;
         BC00027_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC00027_A1EspectaculoId = new short[1] ;
         BC00027_A4LugarId = new short[1] ;
         BC000213_A3EventoId = new short[1] ;
         BC000216_A8VentaId = new short[1] ;
         BC000217_A3EventoId = new short[1] ;
         BC000217_A17EventoHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC000217_A1EspectaculoId = new short[1] ;
         BC000217_A4LugarId = new short[1] ;
         Z10SectorNombre = "";
         A10SectorNombre = "";
         BC000218_A3EventoId = new short[1] ;
         BC000218_A10SectorNombre = new string[] {""} ;
         BC000218_A20SectorCapacidad = new short[1] ;
         BC000218_A21SectorPrecio = new short[1] ;
         BC000218_A5SectorId = new short[1] ;
         BC00026_A10SectorNombre = new string[] {""} ;
         BC00026_A20SectorCapacidad = new short[1] ;
         BC00026_A21SectorPrecio = new short[1] ;
         BC000219_A3EventoId = new short[1] ;
         BC000219_A5SectorId = new short[1] ;
         BC00025_A3EventoId = new short[1] ;
         BC00025_A5SectorId = new short[1] ;
         sMode3 = "";
         BC00024_A3EventoId = new short[1] ;
         BC00024_A5SectorId = new short[1] ;
         BC000222_A10SectorNombre = new string[] {""} ;
         BC000222_A20SectorCapacidad = new short[1] ;
         BC000222_A21SectorPrecio = new short[1] ;
         BC000223_A8VentaId = new short[1] ;
         BC000224_A6InvitacionId = new short[1] ;
         BC000225_A3EventoId = new short[1] ;
         BC000225_A10SectorNombre = new string[] {""} ;
         BC000225_A20SectorCapacidad = new short[1] ;
         BC000225_A21SectorPrecio = new short[1] ;
         BC000225_A5SectorId = new short[1] ;
         Z18InvitacionNombre = "";
         A18InvitacionNombre = "";
         BC000226_A6InvitacionId = new short[1] ;
         BC000226_A18InvitacionNombre = new string[] {""} ;
         BC000226_A19InvitacionNominada = new bool[] {false} ;
         BC000227_A6InvitacionId = new short[1] ;
         BC00023_A6InvitacionId = new short[1] ;
         BC00023_A18InvitacionNombre = new string[] {""} ;
         BC00023_A19InvitacionNominada = new bool[] {false} ;
         sMode5 = "";
         BC00022_A6InvitacionId = new short[1] ;
         BC00022_A18InvitacionNombre = new string[] {""} ;
         BC00022_A19InvitacionNominada = new bool[] {false} ;
         BC000228_A6InvitacionId = new short[1] ;
         BC000231_A6InvitacionId = new short[1] ;
         BC000231_A18InvitacionNombre = new string[] {""} ;
         BC000231_A19InvitacionNominada = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.evento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A6InvitacionId, BC00022_A18InvitacionNombre, BC00022_A19InvitacionNominada
               }
               , new Object[] {
               BC00023_A6InvitacionId, BC00023_A18InvitacionNombre, BC00023_A19InvitacionNominada
               }
               , new Object[] {
               BC00024_A3EventoId, BC00024_A5SectorId
               }
               , new Object[] {
               BC00025_A3EventoId, BC00025_A5SectorId
               }
               , new Object[] {
               BC00026_A10SectorNombre, BC00026_A20SectorCapacidad, BC00026_A21SectorPrecio
               }
               , new Object[] {
               BC00027_A3EventoId, BC00027_A17EventoHoraFecha, BC00027_A1EspectaculoId, BC00027_A4LugarId
               }
               , new Object[] {
               BC00028_A3EventoId, BC00028_A17EventoHoraFecha, BC00028_A1EspectaculoId, BC00028_A4LugarId
               }
               , new Object[] {
               BC00029_A1EspectaculoId
               }
               , new Object[] {
               BC000210_A4LugarId
               }
               , new Object[] {
               BC000211_A3EventoId, BC000211_A17EventoHoraFecha, BC000211_A1EspectaculoId, BC000211_A4LugarId
               }
               , new Object[] {
               BC000212_A3EventoId
               }
               , new Object[] {
               BC000213_A3EventoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000216_A8VentaId
               }
               , new Object[] {
               BC000217_A3EventoId, BC000217_A17EventoHoraFecha, BC000217_A1EspectaculoId, BC000217_A4LugarId
               }
               , new Object[] {
               BC000218_A3EventoId, BC000218_A10SectorNombre, BC000218_A20SectorCapacidad, BC000218_A21SectorPrecio, BC000218_A5SectorId
               }
               , new Object[] {
               BC000219_A3EventoId, BC000219_A5SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000222_A10SectorNombre, BC000222_A20SectorCapacidad, BC000222_A21SectorPrecio
               }
               , new Object[] {
               BC000223_A8VentaId
               }
               , new Object[] {
               BC000224_A6InvitacionId
               }
               , new Object[] {
               BC000225_A3EventoId, BC000225_A10SectorNombre, BC000225_A20SectorCapacidad, BC000225_A21SectorPrecio, BC000225_A5SectorId
               }
               , new Object[] {
               BC000226_A6InvitacionId, BC000226_A18InvitacionNombre, BC000226_A19InvitacionNominada
               }
               , new Object[] {
               BC000227_A6InvitacionId
               }
               , new Object[] {
               BC000228_A6InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000231_A6InvitacionId, BC000231_A18InvitacionNombre, BC000231_A19InvitacionNominada
               }
            }
         );
         Z3EventoId = 0;
         A3EventoId = 0;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z3EventoId ;
      private short A3EventoId ;
      private short nIsMod_5 ;
      private short RcdFound5 ;
      private short nIsMod_3 ;
      private short RcdFound3 ;
      private short Z1EspectaculoId ;
      private short A1EspectaculoId ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short RcdFound2 ;
      private short nRcdExists_3 ;
      private short nRcdExists_5 ;
      private short Z25SectorCupoActual ;
      private short A25SectorCupoActual ;
      private short Z20SectorCapacidad ;
      private short A20SectorCapacidad ;
      private short Z21SectorPrecio ;
      private short A21SectorPrecio ;
      private short Z5SectorId ;
      private short A5SectorId ;
      private short Gx_BScreen ;
      private short GXt_int1 ;
      private short Gxremove3 ;
      private short Z6InvitacionId ;
      private short A6InvitacionId ;
      private short Gxremove5 ;
      private int trnEnded ;
      private int nGXsfl_5_idx=1 ;
      private int nGXsfl_3_idx=1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private string sMode3 ;
      private string sMode5 ;
      private DateTime Z17EventoHoraFecha ;
      private DateTime A17EventoHoraFecha ;
      private bool returnInSub ;
      private bool Z19InvitacionNominada ;
      private bool A19InvitacionNominada ;
      private string Z10SectorNombre ;
      private string A10SectorNombre ;
      private string Z18InvitacionNombre ;
      private string A18InvitacionNombre ;
      private IGxDataStore dsDefault ;
      private SdtEvento bcEvento ;
      private IDataStoreProvider pr_default ;
      private short[] BC000211_A3EventoId ;
      private DateTime[] BC000211_A17EventoHoraFecha ;
      private short[] BC000211_A1EspectaculoId ;
      private short[] BC000211_A4LugarId ;
      private short[] BC00029_A1EspectaculoId ;
      private short[] BC000210_A4LugarId ;
      private short[] BC000212_A3EventoId ;
      private short[] BC00028_A3EventoId ;
      private DateTime[] BC00028_A17EventoHoraFecha ;
      private short[] BC00028_A1EspectaculoId ;
      private short[] BC00028_A4LugarId ;
      private short[] BC00027_A3EventoId ;
      private DateTime[] BC00027_A17EventoHoraFecha ;
      private short[] BC00027_A1EspectaculoId ;
      private short[] BC00027_A4LugarId ;
      private short[] BC000213_A3EventoId ;
      private short[] BC000216_A8VentaId ;
      private short[] BC000217_A3EventoId ;
      private DateTime[] BC000217_A17EventoHoraFecha ;
      private short[] BC000217_A1EspectaculoId ;
      private short[] BC000217_A4LugarId ;
      private short[] BC000218_A3EventoId ;
      private string[] BC000218_A10SectorNombre ;
      private short[] BC000218_A20SectorCapacidad ;
      private short[] BC000218_A21SectorPrecio ;
      private short[] BC000218_A5SectorId ;
      private string[] BC00026_A10SectorNombre ;
      private short[] BC00026_A20SectorCapacidad ;
      private short[] BC00026_A21SectorPrecio ;
      private short[] BC000219_A3EventoId ;
      private short[] BC000219_A5SectorId ;
      private short[] BC00025_A3EventoId ;
      private short[] BC00025_A5SectorId ;
      private short[] BC00024_A3EventoId ;
      private short[] BC00024_A5SectorId ;
      private string[] BC000222_A10SectorNombre ;
      private short[] BC000222_A20SectorCapacidad ;
      private short[] BC000222_A21SectorPrecio ;
      private short[] BC000223_A8VentaId ;
      private short[] BC000224_A6InvitacionId ;
      private short[] BC000225_A3EventoId ;
      private string[] BC000225_A10SectorNombre ;
      private short[] BC000225_A20SectorCapacidad ;
      private short[] BC000225_A21SectorPrecio ;
      private short[] BC000225_A5SectorId ;
      private short[] BC000226_A6InvitacionId ;
      private string[] BC000226_A18InvitacionNombre ;
      private bool[] BC000226_A19InvitacionNominada ;
      private short[] BC000227_A6InvitacionId ;
      private short[] BC00023_A6InvitacionId ;
      private string[] BC00023_A18InvitacionNombre ;
      private bool[] BC00023_A19InvitacionNominada ;
      private short[] BC00022_A6InvitacionId ;
      private string[] BC00022_A18InvitacionNombre ;
      private bool[] BC00022_A19InvitacionNominada ;
      private short[] BC000228_A6InvitacionId ;
      private short[] BC000231_A6InvitacionId ;
      private string[] BC000231_A18InvitacionNombre ;
      private bool[] BC000231_A19InvitacionNominada ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class evento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new ForEachCursor(def[29])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@EventoHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@EventoHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000217;
          prmBC000217 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000219;
          prmBC000219 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000220;
          prmBC000220 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000221;
          prmBC000221 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000222;
          prmBC000222 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000223;
          prmBC000223 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000224;
          prmBC000224 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000225;
          prmBC000225 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0)
          };
          Object[] prmBC000226;
          prmBC000226 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000227;
          prmBC000227 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000228;
          prmBC000228 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0)
          };
          Object[] prmBC000229;
          prmBC000229 = new Object[] {
          new ParDef("@InvitacionNombre",GXType.NVarChar,100,0) ,
          new ParDef("@InvitacionNominada",GXType.Boolean,4,0) ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000230;
          prmBC000230 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmBC000231;
          prmBC000231 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [EventoId], [SectorId] FROM [EventoSector] WITH (UPDLOCK) WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [EventoId], [SectorId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT [EventoId], [EventoHoraFecha], [EspectaculoId], [LugarId] FROM [Evento] WITH (UPDLOCK) WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT [EventoId], [EventoHoraFecha], [EspectaculoId], [LugarId] FROM [Evento] WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000210", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000211", "SELECT TM1.[EventoId], TM1.[EventoHoraFecha], TM1.[EspectaculoId], TM1.[LugarId] FROM [Evento] TM1 WHERE TM1.[EventoId] = @EventoId ORDER BY TM1.[EventoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000212", "SELECT [EventoId] FROM [Evento] WHERE [EventoId] = @EventoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000213", "INSERT INTO [Evento]([EventoHoraFecha], [EspectaculoId], [LugarId]) VALUES(@EventoHoraFecha, @EspectaculoId, @LugarId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000214", "UPDATE [Evento] SET [EventoHoraFecha]=@EventoHoraFecha, [EspectaculoId]=@EspectaculoId, [LugarId]=@LugarId  WHERE [EventoId] = @EventoId", GxErrorMask.GX_NOMASK,prmBC000214)
             ,new CursorDef("BC000215", "DELETE FROM [Evento]  WHERE [EventoId] = @EventoId", GxErrorMask.GX_NOMASK,prmBC000215)
             ,new CursorDef("BC000216", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE [EventoId] = @EventoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000217", "SELECT TM1.[EventoId], TM1.[EventoHoraFecha], TM1.[EspectaculoId], TM1.[LugarId] FROM [Evento] TM1 WHERE TM1.[EventoId] = @EventoId ORDER BY TM1.[EventoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000217,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000218", "SELECT T1.[EventoId], T2.[SectorNombre], T2.[SectorCapacidad], T2.[SectorPrecio], T1.[SectorId] FROM ([EventoSector] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) WHERE T1.[EventoId] = @EventoId and T1.[SectorId] = @SectorId ORDER BY T1.[EventoId], T1.[SectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000219", "SELECT [EventoId], [SectorId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000220", "INSERT INTO [EventoSector]([EventoId], [SectorId]) VALUES(@EventoId, @SectorId)", GxErrorMask.GX_NOMASK,prmBC000220)
             ,new CursorDef("BC000221", "DELETE FROM [EventoSector]  WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmBC000221)
             ,new CursorDef("BC000222", "SELECT [SectorNombre], [SectorCapacidad], [SectorPrecio] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000222,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000223", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000223,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000224", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000224,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000225", "SELECT T1.[EventoId], T2.[SectorNombre], T2.[SectorCapacidad], T2.[SectorPrecio], T1.[SectorId] FROM ([EventoSector] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) WHERE T1.[EventoId] = @EventoId ORDER BY T1.[EventoId], T1.[SectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000225,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000226", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ORDER BY [InvitacionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000226,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000227", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000227,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000228", "INSERT INTO [Invitacion]([InvitacionNombre], [InvitacionNominada], [EventoId], [SectorId]) VALUES(@InvitacionNombre, @InvitacionNominada, convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000228,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000229", "UPDATE [Invitacion] SET [InvitacionNombre]=@InvitacionNombre, [InvitacionNominada]=@InvitacionNominada  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC000229)
             ,new CursorDef("BC000230", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmBC000230)
             ,new CursorDef("BC000231", "SELECT [InvitacionId], [InvitacionNombre], [InvitacionNominada] FROM [Invitacion] ORDER BY [InvitacionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000231,11, GxCacheFrequency.OFF ,true,false )
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
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
