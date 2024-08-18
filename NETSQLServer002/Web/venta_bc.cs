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
   public class venta_bc : GxSilentTrn, IGxSilentTrn
   {
      public venta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public venta_bc( IGxContext context )
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
         ReadRow0810( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0810( ) ;
         standaloneModal( ) ;
         AddRow0810( ) ;
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
            E11082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z8VentaId = A8VentaId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0810( ) ;
            }
            else
            {
               CheckExtendedTable0810( ) ;
               if ( AnyError == 0 )
               {
                  ZM0810( 3) ;
               }
               CloseExtendedTableCursors0810( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12082( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            context.PopUp(formatLink("agenerarticketpdf.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A8VentaId,4,0))}, new string[] {"VentaId"}) , new Object[] {});
            new actualizarfecha(context ).execute(  A8VentaId) ;
            AV14EventoId = AV11Insert_EventoId;
            AV15SectorId = AV12Insert_SectorId;
            GXt_int1 = AV16CupoActual;
            new calcularcupoactual(context ).execute(  AV15SectorId,  AV14EventoId, out  GXt_int1) ;
            AV16CupoActual = GXt_int1;
            if ( AV16CupoActual <= 0 )
            {
               GX_msglist.addItem("No hay cupos disponibles en este sector.");
            }
         }
      }

      protected void ZM0810( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z23VentaHoraFecha = A23VentaHoraFecha;
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z8VentaId = A8VentaId;
            Z23VentaHoraFecha = A23VentaHoraFecha;
            Z3EventoId = A3EventoId;
            Z5SectorId = A5SectorId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0810( )
      {
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {A8VentaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound10 = 1;
            A23VentaHoraFecha = BC00085_A23VentaHoraFecha[0];
            A3EventoId = BC00085_A3EventoId[0];
            A5SectorId = BC00085_A5SectorId[0];
            ZM0810( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0810( ) ;
      }

      protected void OnLoadActions0810( )
      {
      }

      protected void CheckExtendedTable0810( )
      {
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A23VentaHoraFecha) || ( A23VentaHoraFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Field Venta Hora Fecha is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A3EventoId, A5SectorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'EventoSector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0810( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0810( )
      {
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {A8VentaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A8VentaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0810( 2) ;
            RcdFound10 = 1;
            A8VentaId = BC00083_A8VentaId[0];
            A23VentaHoraFecha = BC00083_A23VentaHoraFecha[0];
            A3EventoId = BC00083_A3EventoId[0];
            A5SectorId = BC00083_A5SectorId[0];
            Z8VentaId = A8VentaId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0810( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0810( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0810( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0810( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0810( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A8VentaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Venta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z23VentaHoraFecha != BC00082_A23VentaHoraFecha[0] ) || ( Z3EventoId != BC00082_A3EventoId[0] ) || ( Z5SectorId != BC00082_A5SectorId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Venta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0810( )
      {
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0810( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0810( 0) ;
            CheckOptimisticConcurrency0810( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0810( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0810( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00087 */
                     pr_default.execute(5, new Object[] {A23VentaHoraFecha, A3EventoId, A5SectorId});
                     A8VentaId = BC00087_A8VentaId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Venta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load0810( ) ;
            }
            EndLevel0810( ) ;
         }
         CloseExtendedTableCursors0810( ) ;
      }

      protected void Update0810( )
      {
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0810( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0810( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0810( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0810( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00088 */
                     pr_default.execute(6, new Object[] {A23VentaHoraFecha, A3EventoId, A5SectorId, A8VentaId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Venta");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Venta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0810( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel0810( ) ;
         }
         CloseExtendedTableCursors0810( ) ;
      }

      protected void DeferredUpdate0810( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0810( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0810( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0810( ) ;
            AfterConfirm0810( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0810( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00089 */
                  pr_default.execute(7, new Object[] {A8VentaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Venta");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0810( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0810( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0810( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0810( ) ;
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

      public void ScanKeyStart0810( )
      {
         /* Scan By routine */
         /* Using cursor BC000810 */
         pr_default.execute(8, new Object[] {A8VentaId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A8VentaId = BC000810_A8VentaId[0];
            A23VentaHoraFecha = BC000810_A23VentaHoraFecha[0];
            A3EventoId = BC000810_A3EventoId[0];
            A5SectorId = BC000810_A5SectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0810( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound10 = 0;
         ScanKeyLoad0810( ) ;
      }

      protected void ScanKeyLoad0810( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
            A8VentaId = BC000810_A8VentaId[0];
            A23VentaHoraFecha = BC000810_A23VentaHoraFecha[0];
            A3EventoId = BC000810_A3EventoId[0];
            A5SectorId = BC000810_A5SectorId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0810( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0810( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0810( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0810( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0810( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0810( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0810( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0810( )
      {
      }

      protected void send_integrity_lvl_hashes0810( )
      {
      }

      protected void AddRow0810( )
      {
         VarsToRow10( bcVenta) ;
      }

      protected void ReadRow0810( )
      {
         RowToVars10( bcVenta, 1) ;
      }

      protected void InitializeNonKey0810( )
      {
         A23VentaHoraFecha = (DateTime)(DateTime.MinValue);
         A5SectorId = 0;
         A3EventoId = 0;
         Z23VentaHoraFecha = (DateTime)(DateTime.MinValue);
         Z3EventoId = 0;
         Z5SectorId = 0;
      }

      protected void InitAll0810( )
      {
         A8VentaId = 0;
         InitializeNonKey0810( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow10( SdtVenta obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Ventahorafecha = A23VentaHoraFecha;
         obj10.gxTpr_Sectorid = A5SectorId;
         obj10.gxTpr_Eventoid = A3EventoId;
         obj10.gxTpr_Ventaid = A8VentaId;
         obj10.gxTpr_Ventaid_Z = Z8VentaId;
         obj10.gxTpr_Ventahorafecha_Z = Z23VentaHoraFecha;
         obj10.gxTpr_Sectorid_Z = Z5SectorId;
         obj10.gxTpr_Eventoid_Z = Z3EventoId;
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( SdtVenta obj10 )
      {
         obj10.gxTpr_Ventaid = A8VentaId;
         return  ;
      }

      public void RowToVars10( SdtVenta obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A23VentaHoraFecha = obj10.gxTpr_Ventahorafecha;
         A5SectorId = obj10.gxTpr_Sectorid;
         A3EventoId = obj10.gxTpr_Eventoid;
         A8VentaId = obj10.gxTpr_Ventaid;
         Z8VentaId = obj10.gxTpr_Ventaid_Z;
         Z23VentaHoraFecha = obj10.gxTpr_Ventahorafecha_Z;
         Z5SectorId = obj10.gxTpr_Sectorid_Z;
         Z3EventoId = obj10.gxTpr_Eventoid_Z;
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A8VentaId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0810( ) ;
         ScanKeyStart0810( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8VentaId = A8VentaId;
         }
         ZM0810( -2) ;
         OnLoadActions0810( ) ;
         AddRow0810( ) ;
         ScanKeyEnd0810( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcVenta, 0) ;
         ScanKeyStart0810( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z8VentaId = A8VentaId;
         }
         ZM0810( -2) ;
         OnLoadActions0810( ) ;
         AddRow0810( ) ;
         ScanKeyEnd0810( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0810( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0810( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A8VentaId != Z8VentaId )
               {
                  A8VentaId = Z8VentaId;
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
                  Update0810( ) ;
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
                  if ( A8VentaId != Z8VentaId )
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
                        Insert0810( ) ;
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
                        Insert0810( ) ;
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
         RowToVars10( bcVenta, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcVenta) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars10( bcVenta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0810( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcVenta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcVenta) ;
         }
         else
         {
            SdtVenta auxBC = new SdtVenta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A8VentaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcVenta);
               auxBC.Save();
               bcVenta.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars10( bcVenta, 1) ;
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
         RowToVars10( bcVenta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0810( ) ;
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
               VarsToRow10( bcVenta) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcVenta) ;
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
         RowToVars10( bcVenta, 0) ;
         GetKey0810( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A8VentaId != Z8VentaId )
            {
               A8VentaId = Z8VentaId;
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
            if ( A8VentaId != Z8VentaId )
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
         pr_default.close(1);
         context.RollbackDataStores("venta_bc",pr_default);
         VarsToRow10( bcVenta) ;
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
         Gx_mode = bcVenta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcVenta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcVenta )
         {
            bcVenta = (SdtVenta)(sdt);
            if ( StringUtil.StrCmp(bcVenta.gxTpr_Mode, "") == 0 )
            {
               bcVenta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcVenta) ;
            }
            else
            {
               RowToVars10( bcVenta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcVenta.gxTpr_Mode, "") == 0 )
            {
               bcVenta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcVenta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtVenta Venta_BC
      {
         get {
            return bcVenta ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z23VentaHoraFecha = (DateTime)(DateTime.MinValue);
         A23VentaHoraFecha = (DateTime)(DateTime.MinValue);
         BC00085_A8VentaId = new short[1] ;
         BC00085_A23VentaHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC00085_A3EventoId = new short[1] ;
         BC00085_A5SectorId = new short[1] ;
         BC00084_A3EventoId = new short[1] ;
         BC00086_A8VentaId = new short[1] ;
         BC00083_A8VentaId = new short[1] ;
         BC00083_A23VentaHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC00083_A3EventoId = new short[1] ;
         BC00083_A5SectorId = new short[1] ;
         sMode10 = "";
         BC00082_A8VentaId = new short[1] ;
         BC00082_A23VentaHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC00082_A3EventoId = new short[1] ;
         BC00082_A5SectorId = new short[1] ;
         BC00087_A8VentaId = new short[1] ;
         BC000810_A8VentaId = new short[1] ;
         BC000810_A23VentaHoraFecha = new DateTime[] {DateTime.MinValue} ;
         BC000810_A3EventoId = new short[1] ;
         BC000810_A5SectorId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.venta_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A8VentaId, BC00082_A23VentaHoraFecha, BC00082_A3EventoId, BC00082_A5SectorId
               }
               , new Object[] {
               BC00083_A8VentaId, BC00083_A23VentaHoraFecha, BC00083_A3EventoId, BC00083_A5SectorId
               }
               , new Object[] {
               BC00084_A3EventoId
               }
               , new Object[] {
               BC00085_A8VentaId, BC00085_A23VentaHoraFecha, BC00085_A3EventoId, BC00085_A5SectorId
               }
               , new Object[] {
               BC00086_A8VentaId
               }
               , new Object[] {
               BC00087_A8VentaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000810_A8VentaId, BC000810_A23VentaHoraFecha, BC000810_A3EventoId, BC000810_A5SectorId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12082 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z8VentaId ;
      private short A8VentaId ;
      private short AV14EventoId ;
      private short AV11Insert_EventoId ;
      private short AV15SectorId ;
      private short AV12Insert_SectorId ;
      private short AV16CupoActual ;
      private short GXt_int1 ;
      private short Z3EventoId ;
      private short A3EventoId ;
      private short Z5SectorId ;
      private short A5SectorId ;
      private short RcdFound10 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private DateTime Z23VentaHoraFecha ;
      private DateTime A23VentaHoraFecha ;
      private bool returnInSub ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00085_A8VentaId ;
      private DateTime[] BC00085_A23VentaHoraFecha ;
      private short[] BC00085_A3EventoId ;
      private short[] BC00085_A5SectorId ;
      private short[] BC00084_A3EventoId ;
      private short[] BC00086_A8VentaId ;
      private short[] BC00083_A8VentaId ;
      private DateTime[] BC00083_A23VentaHoraFecha ;
      private short[] BC00083_A3EventoId ;
      private short[] BC00083_A5SectorId ;
      private short[] BC00082_A8VentaId ;
      private DateTime[] BC00082_A23VentaHoraFecha ;
      private short[] BC00082_A3EventoId ;
      private short[] BC00082_A5SectorId ;
      private short[] BC00087_A8VentaId ;
      private short[] BC000810_A8VentaId ;
      private DateTime[] BC000810_A23VentaHoraFecha ;
      private short[] BC000810_A3EventoId ;
      private short[] BC000810_A5SectorId ;
      private SdtVenta bcVenta ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class venta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00082;
          prmBC00082 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC00083;
          prmBC00083 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC00084;
          prmBC00084 = new Object[] {
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00085;
          prmBC00085 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC00086;
          prmBC00086 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC00087;
          prmBC00087 = new Object[] {
          new ParDef("@VentaHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00088;
          prmBC00088 = new Object[] {
          new ParDef("@VentaHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@EventoId",GXType.Int16,4,0) ,
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC00089;
          prmBC00089 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmBC000810;
          prmBC000810 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00082", "SELECT [VentaId], [VentaHoraFecha], [EventoId], [SectorId] FROM [Venta] WITH (UPDLOCK) WHERE [VentaId] = @VentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00083", "SELECT [VentaId], [VentaHoraFecha], [EventoId], [SectorId] FROM [Venta] WHERE [VentaId] = @VentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00084", "SELECT [EventoId] FROM [EventoSector] WHERE [EventoId] = @EventoId AND [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00085", "SELECT TM1.[VentaId], TM1.[VentaHoraFecha], TM1.[EventoId], TM1.[SectorId] FROM [Venta] TM1 WHERE TM1.[VentaId] = @VentaId ORDER BY TM1.[VentaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00086", "SELECT [VentaId] FROM [Venta] WHERE [VentaId] = @VentaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00087", "INSERT INTO [Venta]([VentaHoraFecha], [EventoId], [SectorId]) VALUES(@VentaHoraFecha, @EventoId, @SectorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00088", "UPDATE [Venta] SET [VentaHoraFecha]=@VentaHoraFecha, [EventoId]=@EventoId, [SectorId]=@SectorId  WHERE [VentaId] = @VentaId", GxErrorMask.GX_NOMASK,prmBC00088)
             ,new CursorDef("BC00089", "DELETE FROM [Venta]  WHERE [VentaId] = @VentaId", GxErrorMask.GX_NOMASK,prmBC00089)
             ,new CursorDef("BC000810", "SELECT TM1.[VentaId], TM1.[VentaHoraFecha], TM1.[EventoId], TM1.[SectorId] FROM [Venta] TM1 WHERE TM1.[VentaId] = @VentaId ORDER BY TM1.[VentaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000810,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
