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
   public class espectaculo_bc : GxSilentTrn, IGxSilentTrn
   {
      public espectaculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public espectaculo_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1EspectaculoId = A1EspectaculoId;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
                  ZM011( 2) ;
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z14EspectaculoNombre = A14EspectaculoNombre;
            Z15EspectaculoDescripcion = A15EspectaculoDescripcion;
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z14EspectaculoNombre = A14EspectaculoNombre;
            Z15EspectaculoDescripcion = A15EspectaculoDescripcion;
            Z16EspectaculoImagen = A16EspectaculoImagen;
            Z40000EspectaculoImagen_GXI = A40000EspectaculoImagen_GXI;
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A14EspectaculoNombre = BC00015_A14EspectaculoNombre[0];
            A15EspectaculoDescripcion = BC00015_A15EspectaculoDescripcion[0];
            A40000EspectaculoImagen_GXI = BC00015_A40000EspectaculoImagen_GXI[0];
            A2TipoEspectaculoId = BC00015_A2TipoEspectaculoId[0];
            A16EspectaculoImagen = BC00015_A16EspectaculoImagen[0];
            ZM011( -1) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 1) ;
            RcdFound1 = 1;
            A1EspectaculoId = BC00013_A1EspectaculoId[0];
            A14EspectaculoNombre = BC00013_A14EspectaculoNombre[0];
            A15EspectaculoDescripcion = BC00013_A15EspectaculoDescripcion[0];
            A40000EspectaculoImagen_GXI = BC00013_A40000EspectaculoImagen_GXI[0];
            A2TipoEspectaculoId = BC00013_A2TipoEspectaculoId[0];
            A16EspectaculoImagen = BC00013_A16EspectaculoImagen[0];
            Z1EspectaculoId = A1EspectaculoId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14EspectaculoNombre, BC00012_A14EspectaculoNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z15EspectaculoDescripcion, BC00012_A15EspectaculoDescripcion[0]) != 0 ) || ( Z2TipoEspectaculoId != BC00012_A2TipoEspectaculoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A14EspectaculoNombre, A15EspectaculoDescripcion, A16EspectaculoImagen, A40000EspectaculoImagen_GXI, A2TipoEspectaculoId});
                     A1EspectaculoId = BC00017_A1EspectaculoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A14EspectaculoNombre, A15EspectaculoDescripcion, A2TipoEspectaculoId, A1EspectaculoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A16EspectaculoImagen, A40000EspectaculoImagen_GXI, A1EspectaculoId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {A1EspectaculoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Espectaculo");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Evento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000112 */
         pr_default.execute(10, new Object[] {A1EspectaculoId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = BC000112_A1EspectaculoId[0];
            A14EspectaculoNombre = BC000112_A14EspectaculoNombre[0];
            A15EspectaculoDescripcion = BC000112_A15EspectaculoDescripcion[0];
            A40000EspectaculoImagen_GXI = BC000112_A40000EspectaculoImagen_GXI[0];
            A2TipoEspectaculoId = BC000112_A2TipoEspectaculoId[0];
            A16EspectaculoImagen = BC000112_A16EspectaculoImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = BC000112_A1EspectaculoId[0];
            A14EspectaculoNombre = BC000112_A14EspectaculoNombre[0];
            A15EspectaculoDescripcion = BC000112_A15EspectaculoDescripcion[0];
            A40000EspectaculoImagen_GXI = BC000112_A40000EspectaculoImagen_GXI[0];
            A2TipoEspectaculoId = BC000112_A2TipoEspectaculoId[0];
            A16EspectaculoImagen = BC000112_A16EspectaculoImagen[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcEspectaculo) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcEspectaculo, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A14EspectaculoNombre = "";
         A15EspectaculoDescripcion = "";
         A16EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         A2TipoEspectaculoId = 0;
         Z14EspectaculoNombre = "";
         Z15EspectaculoDescripcion = "";
         Z2TipoEspectaculoId = 0;
      }

      protected void InitAll011( )
      {
         A1EspectaculoId = 0;
         InitializeNonKey011( ) ;
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

      public void VarsToRow1( SdtEspectaculo obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Espectaculonombre = A14EspectaculoNombre;
         obj1.gxTpr_Espectaculodescripcion = A15EspectaculoDescripcion;
         obj1.gxTpr_Espectaculoimagen = A16EspectaculoImagen;
         obj1.gxTpr_Espectaculoimagen_gxi = A40000EspectaculoImagen_GXI;
         obj1.gxTpr_Tipoespectaculoid = A2TipoEspectaculoId;
         obj1.gxTpr_Espectaculoid = A1EspectaculoId;
         obj1.gxTpr_Espectaculoid_Z = Z1EspectaculoId;
         obj1.gxTpr_Espectaculonombre_Z = Z14EspectaculoNombre;
         obj1.gxTpr_Espectaculodescripcion_Z = Z15EspectaculoDescripcion;
         obj1.gxTpr_Tipoespectaculoid_Z = Z2TipoEspectaculoId;
         obj1.gxTpr_Espectaculoimagen_gxi_Z = Z40000EspectaculoImagen_GXI;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtEspectaculo obj1 )
      {
         obj1.gxTpr_Espectaculoid = A1EspectaculoId;
         return  ;
      }

      public void RowToVars1( SdtEspectaculo obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A14EspectaculoNombre = obj1.gxTpr_Espectaculonombre;
         A15EspectaculoDescripcion = obj1.gxTpr_Espectaculodescripcion;
         A16EspectaculoImagen = obj1.gxTpr_Espectaculoimagen;
         A40000EspectaculoImagen_GXI = obj1.gxTpr_Espectaculoimagen_gxi;
         A2TipoEspectaculoId = obj1.gxTpr_Tipoespectaculoid;
         A1EspectaculoId = obj1.gxTpr_Espectaculoid;
         Z1EspectaculoId = obj1.gxTpr_Espectaculoid_Z;
         Z14EspectaculoNombre = obj1.gxTpr_Espectaculonombre_Z;
         Z15EspectaculoDescripcion = obj1.gxTpr_Espectaculodescripcion_Z;
         Z2TipoEspectaculoId = obj1.gxTpr_Tipoespectaculoid_Z;
         Z40000EspectaculoImagen_GXI = obj1.gxTpr_Espectaculoimagen_gxi_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1EspectaculoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EspectaculoId = A1EspectaculoId;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bcEspectaculo, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EspectaculoId = A1EspectaculoId;
         }
         ZM011( -1) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  A1EspectaculoId = Z1EspectaculoId;
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
                  Update011( ) ;
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
                  if ( A1EspectaculoId != Z1EspectaculoId )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bcEspectaculo, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcEspectaculo) ;
         }
         else
         {
            SdtEspectaculo auxBC = new SdtEspectaculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1EspectaculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEspectaculo);
               auxBC.Save();
               bcEspectaculo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bcEspectaculo, 1) ;
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
         RowToVars1( bcEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
               VarsToRow1( bcEspectaculo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcEspectaculo) ;
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
         RowToVars1( bcEspectaculo, 0) ;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1EspectaculoId != Z1EspectaculoId )
            {
               A1EspectaculoId = Z1EspectaculoId;
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
            if ( A1EspectaculoId != Z1EspectaculoId )
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
         context.RollbackDataStores("espectaculo_bc",pr_default);
         VarsToRow1( bcEspectaculo) ;
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
         Gx_mode = bcEspectaculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEspectaculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEspectaculo )
         {
            bcEspectaculo = (SdtEspectaculo)(sdt);
            if ( StringUtil.StrCmp(bcEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcEspectaculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcEspectaculo) ;
            }
            else
            {
               RowToVars1( bcEspectaculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcEspectaculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcEspectaculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEspectaculo Espectaculo_BC
      {
         get {
            return bcEspectaculo ;
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
         Z14EspectaculoNombre = "";
         A14EspectaculoNombre = "";
         Z15EspectaculoDescripcion = "";
         A15EspectaculoDescripcion = "";
         Z16EspectaculoImagen = "";
         A16EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         A40000EspectaculoImagen_GXI = "";
         BC00015_A1EspectaculoId = new short[1] ;
         BC00015_A14EspectaculoNombre = new string[] {""} ;
         BC00015_A15EspectaculoDescripcion = new string[] {""} ;
         BC00015_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC00015_A2TipoEspectaculoId = new short[1] ;
         BC00015_A16EspectaculoImagen = new string[] {""} ;
         BC00014_A2TipoEspectaculoId = new short[1] ;
         BC00016_A1EspectaculoId = new short[1] ;
         BC00013_A1EspectaculoId = new short[1] ;
         BC00013_A14EspectaculoNombre = new string[] {""} ;
         BC00013_A15EspectaculoDescripcion = new string[] {""} ;
         BC00013_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC00013_A2TipoEspectaculoId = new short[1] ;
         BC00013_A16EspectaculoImagen = new string[] {""} ;
         sMode1 = "";
         BC00012_A1EspectaculoId = new short[1] ;
         BC00012_A14EspectaculoNombre = new string[] {""} ;
         BC00012_A15EspectaculoDescripcion = new string[] {""} ;
         BC00012_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC00012_A2TipoEspectaculoId = new short[1] ;
         BC00012_A16EspectaculoImagen = new string[] {""} ;
         BC00017_A1EspectaculoId = new short[1] ;
         BC000111_A3EventoId = new short[1] ;
         BC000112_A1EspectaculoId = new short[1] ;
         BC000112_A14EspectaculoNombre = new string[] {""} ;
         BC000112_A15EspectaculoDescripcion = new string[] {""} ;
         BC000112_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000112_A2TipoEspectaculoId = new short[1] ;
         BC000112_A16EspectaculoImagen = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1EspectaculoId, BC00012_A14EspectaculoNombre, BC00012_A15EspectaculoDescripcion, BC00012_A40000EspectaculoImagen_GXI, BC00012_A2TipoEspectaculoId, BC00012_A16EspectaculoImagen
               }
               , new Object[] {
               BC00013_A1EspectaculoId, BC00013_A14EspectaculoNombre, BC00013_A15EspectaculoDescripcion, BC00013_A40000EspectaculoImagen_GXI, BC00013_A2TipoEspectaculoId, BC00013_A16EspectaculoImagen
               }
               , new Object[] {
               BC00014_A2TipoEspectaculoId
               }
               , new Object[] {
               BC00015_A1EspectaculoId, BC00015_A14EspectaculoNombre, BC00015_A15EspectaculoDescripcion, BC00015_A40000EspectaculoImagen_GXI, BC00015_A2TipoEspectaculoId, BC00015_A16EspectaculoImagen
               }
               , new Object[] {
               BC00016_A1EspectaculoId
               }
               , new Object[] {
               BC00017_A1EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000111_A3EventoId
               }
               , new Object[] {
               BC000112_A1EspectaculoId, BC000112_A14EspectaculoNombre, BC000112_A15EspectaculoDescripcion, BC000112_A40000EspectaculoImagen_GXI, BC000112_A2TipoEspectaculoId, BC000112_A16EspectaculoImagen
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z1EspectaculoId ;
      private short A1EspectaculoId ;
      private short Z2TipoEspectaculoId ;
      private short A2TipoEspectaculoId ;
      private short RcdFound1 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private bool returnInSub ;
      private string Z14EspectaculoNombre ;
      private string A14EspectaculoNombre ;
      private string Z15EspectaculoDescripcion ;
      private string A15EspectaculoDescripcion ;
      private string Z40000EspectaculoImagen_GXI ;
      private string A40000EspectaculoImagen_GXI ;
      private string Z16EspectaculoImagen ;
      private string A16EspectaculoImagen ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00015_A1EspectaculoId ;
      private string[] BC00015_A14EspectaculoNombre ;
      private string[] BC00015_A15EspectaculoDescripcion ;
      private string[] BC00015_A40000EspectaculoImagen_GXI ;
      private short[] BC00015_A2TipoEspectaculoId ;
      private string[] BC00015_A16EspectaculoImagen ;
      private short[] BC00014_A2TipoEspectaculoId ;
      private short[] BC00016_A1EspectaculoId ;
      private short[] BC00013_A1EspectaculoId ;
      private string[] BC00013_A14EspectaculoNombre ;
      private string[] BC00013_A15EspectaculoDescripcion ;
      private string[] BC00013_A40000EspectaculoImagen_GXI ;
      private short[] BC00013_A2TipoEspectaculoId ;
      private string[] BC00013_A16EspectaculoImagen ;
      private short[] BC00012_A1EspectaculoId ;
      private string[] BC00012_A14EspectaculoNombre ;
      private string[] BC00012_A15EspectaculoDescripcion ;
      private string[] BC00012_A40000EspectaculoImagen_GXI ;
      private short[] BC00012_A2TipoEspectaculoId ;
      private string[] BC00012_A16EspectaculoImagen ;
      private short[] BC00017_A1EspectaculoId ;
      private short[] BC000111_A3EventoId ;
      private short[] BC000112_A1EspectaculoId ;
      private string[] BC000112_A14EspectaculoNombre ;
      private string[] BC000112_A15EspectaculoDescripcion ;
      private string[] BC000112_A40000EspectaculoImagen_GXI ;
      private short[] BC000112_A2TipoEspectaculoId ;
      private string[] BC000112_A16EspectaculoImagen ;
      private SdtEspectaculo bcEspectaculo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class espectaculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@EspectaculoDescripcion",GXType.NVarChar,500,0) ,
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@EspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@EspectaculoDescripcion",GXType.NVarChar,500,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen_GXI], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [EspectaculoId], [EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen_GXI], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoNombre], TM1.[EspectaculoDescripcion], TM1.[EspectaculoImagen_GXI], TM1.[TipoEspectaculoId], TM1.[EspectaculoImagen] FROM [Espectaculo] TM1 WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO [Espectaculo]([EspectaculoNombre], [EspectaculoDescripcion], [EspectaculoImagen], [EspectaculoImagen_GXI], [TipoEspectaculoId]) VALUES(@EspectaculoNombre, @EspectaculoDescripcion, @EspectaculoImagen, @EspectaculoImagen_GXI, @TipoEspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00018", "UPDATE [Espectaculo] SET [EspectaculoNombre]=@EspectaculoNombre, [EspectaculoDescripcion]=@EspectaculoDescripcion, [TipoEspectaculoId]=@TipoEspectaculoId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "UPDATE [Espectaculo] SET [EspectaculoImagen]=@EspectaculoImagen, [EspectaculoImagen_GXI]=@EspectaculoImagen_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "SELECT TOP 1 [EventoId] FROM [Evento] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000112", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoNombre], TM1.[EspectaculoDescripcion], TM1.[EspectaculoImagen_GXI], TM1.[TipoEspectaculoId], TM1.[EspectaculoImagen] FROM [Espectaculo] TM1 WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(4));
                return;
       }
    }

 }

}
