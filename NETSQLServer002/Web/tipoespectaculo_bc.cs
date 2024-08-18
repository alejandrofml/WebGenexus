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
   public class tipoespectaculo_bc : GxSilentTrn, IGxSilentTrn
   {
      public tipoespectaculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public tipoespectaculo_bc( IGxContext context )
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
         ReadRow079( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey079( ) ;
         standaloneModal( ) ;
         AddRow079( ) ;
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
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z2TipoEspectaculoId = A2TipoEspectaculoId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls079( ) ;
            }
            else
            {
               CheckExtendedTable079( ) ;
               if ( AnyError == 0 )
               {
                  ZM079( 2) ;
               }
               CloseExtendedTableCursors079( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12072( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM079( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z12TipoEspectaculoNombre = A12TipoEspectaculoNombre;
            Z38CantidadEspectaculos = A38CantidadEspectaculos;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z38CantidadEspectaculos = A38CantidadEspectaculos;
         }
         if ( GX_JID == -1 )
         {
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
            Z12TipoEspectaculoNombre = A12TipoEspectaculoNombre;
            Z38CantidadEspectaculos = A38CantidadEspectaculos;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load079( )
      {
         /* Using cursor BC00077 */
         pr_default.execute(3, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A12TipoEspectaculoNombre = BC00077_A12TipoEspectaculoNombre[0];
            A38CantidadEspectaculos = BC00077_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = BC00077_n38CantidadEspectaculos[0];
            ZM079( -1) ;
         }
         pr_default.close(3);
         OnLoadActions079( ) ;
      }

      protected void OnLoadActions079( )
      {
      }

      protected void CheckExtendedTable079( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00075 */
         pr_default.execute(2, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A38CantidadEspectaculos = BC00075_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = BC00075_n38CantidadEspectaculos[0];
         }
         else
         {
            A38CantidadEspectaculos = 0;
            n38CantidadEspectaculos = false;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors079( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey079( )
      {
         /* Using cursor BC00078 */
         pr_default.execute(4, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A2TipoEspectaculoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM079( 1) ;
            RcdFound9 = 1;
            A2TipoEspectaculoId = BC00073_A2TipoEspectaculoId[0];
            A12TipoEspectaculoNombre = BC00073_A12TipoEspectaculoNombre[0];
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load079( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey079( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey079( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey079( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_070( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency079( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12TipoEspectaculoNombre, BC00072_A12TipoEspectaculoNombre[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoEspectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM079( 0) ;
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00079 */
                     pr_default.execute(5, new Object[] {A12TipoEspectaculoNombre});
                     A2TipoEspectaculoId = BC00079_A2TipoEspectaculoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
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
               Load079( ) ;
            }
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void Update079( )
      {
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable079( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm079( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate079( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000710 */
                     pr_default.execute(6, new Object[] {A12TipoEspectaculoNombre, A2TipoEspectaculoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoEspectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate079( ) ;
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
            EndLevel079( ) ;
         }
         CloseExtendedTableCursors079( ) ;
      }

      protected void DeferredUpdate079( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate079( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency079( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls079( ) ;
            AfterConfirm079( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete079( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000711 */
                  pr_default.execute(7, new Object[] {A2TipoEspectaculoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("TipoEspectaculo");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel079( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls079( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000713 */
            pr_default.execute(8, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A38CantidadEspectaculos = BC000713_A38CantidadEspectaculos[0];
               n38CantidadEspectaculos = BC000713_n38CantidadEspectaculos[0];
            }
            else
            {
               A38CantidadEspectaculos = 0;
               n38CantidadEspectaculos = false;
            }
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000714 */
            pr_default.execute(9, new Object[] {A2TipoEspectaculoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel079( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete079( ) ;
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

      public void ScanKeyStart079( )
      {
         /* Scan By routine */
         /* Using cursor BC000716 */
         pr_default.execute(10, new Object[] {A2TipoEspectaculoId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
            A2TipoEspectaculoId = BC000716_A2TipoEspectaculoId[0];
            A12TipoEspectaculoNombre = BC000716_A12TipoEspectaculoNombre[0];
            A38CantidadEspectaculos = BC000716_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = BC000716_n38CantidadEspectaculos[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext079( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound9 = 0;
         ScanKeyLoad079( ) ;
      }

      protected void ScanKeyLoad079( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
            A2TipoEspectaculoId = BC000716_A2TipoEspectaculoId[0];
            A12TipoEspectaculoNombre = BC000716_A12TipoEspectaculoNombre[0];
            A38CantidadEspectaculos = BC000716_A38CantidadEspectaculos[0];
            n38CantidadEspectaculos = BC000716_n38CantidadEspectaculos[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd079( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm079( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert079( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate079( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete079( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete079( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate079( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes079( )
      {
      }

      protected void send_integrity_lvl_hashes079( )
      {
      }

      protected void AddRow079( )
      {
         VarsToRow9( bcTipoEspectaculo) ;
      }

      protected void ReadRow079( )
      {
         RowToVars9( bcTipoEspectaculo, 1) ;
      }

      protected void InitializeNonKey079( )
      {
         A12TipoEspectaculoNombre = "";
         A38CantidadEspectaculos = 0;
         n38CantidadEspectaculos = false;
         Z12TipoEspectaculoNombre = "";
      }

      protected void InitAll079( )
      {
         A2TipoEspectaculoId = 0;
         InitializeNonKey079( ) ;
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

      public void VarsToRow9( SdtTipoEspectaculo obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Tipoespectaculonombre = A12TipoEspectaculoNombre;
         obj9.gxTpr_Cantidadespectaculos = A38CantidadEspectaculos;
         obj9.gxTpr_Tipoespectaculoid = A2TipoEspectaculoId;
         obj9.gxTpr_Tipoespectaculoid_Z = Z2TipoEspectaculoId;
         obj9.gxTpr_Tipoespectaculonombre_Z = Z12TipoEspectaculoNombre;
         obj9.gxTpr_Cantidadespectaculos_Z = Z38CantidadEspectaculos;
         obj9.gxTpr_Cantidadespectaculos_N = (short)(Convert.ToInt16(n38CantidadEspectaculos));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtTipoEspectaculo obj9 )
      {
         obj9.gxTpr_Tipoespectaculoid = A2TipoEspectaculoId;
         return  ;
      }

      public void RowToVars9( SdtTipoEspectaculo obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A12TipoEspectaculoNombre = obj9.gxTpr_Tipoespectaculonombre;
         A38CantidadEspectaculos = obj9.gxTpr_Cantidadespectaculos;
         n38CantidadEspectaculos = false;
         A2TipoEspectaculoId = obj9.gxTpr_Tipoespectaculoid;
         Z2TipoEspectaculoId = obj9.gxTpr_Tipoespectaculoid_Z;
         Z12TipoEspectaculoNombre = obj9.gxTpr_Tipoespectaculonombre_Z;
         Z38CantidadEspectaculos = obj9.gxTpr_Cantidadespectaculos_Z;
         n38CantidadEspectaculos = (bool)(Convert.ToBoolean(obj9.gxTpr_Cantidadespectaculos_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A2TipoEspectaculoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey079( ) ;
         ScanKeyStart079( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
         }
         ZM079( -1) ;
         OnLoadActions079( ) ;
         AddRow079( ) ;
         ScanKeyEnd079( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcTipoEspectaculo, 0) ;
         ScanKeyStart079( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2TipoEspectaculoId = A2TipoEspectaculoId;
         }
         ZM079( -1) ;
         OnLoadActions079( ) ;
         AddRow079( ) ;
         ScanKeyEnd079( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey079( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert079( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
               {
                  A2TipoEspectaculoId = Z2TipoEspectaculoId;
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
                  Update079( ) ;
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
                  if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
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
                        Insert079( ) ;
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
                        Insert079( ) ;
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
         RowToVars9( bcTipoEspectaculo, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcTipoEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcTipoEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert079( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcTipoEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcTipoEspectaculo) ;
         }
         else
         {
            SdtTipoEspectaculo auxBC = new SdtTipoEspectaculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A2TipoEspectaculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoEspectaculo);
               auxBC.Save();
               bcTipoEspectaculo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcTipoEspectaculo, 1) ;
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
         RowToVars9( bcTipoEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert079( ) ;
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
               VarsToRow9( bcTipoEspectaculo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcTipoEspectaculo) ;
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
         RowToVars9( bcTipoEspectaculo, 0) ;
         GetKey079( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
            {
               A2TipoEspectaculoId = Z2TipoEspectaculoId;
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
            if ( A2TipoEspectaculoId != Z2TipoEspectaculoId )
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
         pr_default.close(8);
         context.RollbackDataStores("tipoespectaculo_bc",pr_default);
         VarsToRow9( bcTipoEspectaculo) ;
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
         Gx_mode = bcTipoEspectaculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoEspectaculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoEspectaculo )
         {
            bcTipoEspectaculo = (SdtTipoEspectaculo)(sdt);
            if ( StringUtil.StrCmp(bcTipoEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcTipoEspectaculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcTipoEspectaculo) ;
            }
            else
            {
               RowToVars9( bcTipoEspectaculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcTipoEspectaculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcTipoEspectaculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTipoEspectaculo TipoEspectaculo_BC
      {
         get {
            return bcTipoEspectaculo ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z12TipoEspectaculoNombre = "";
         A12TipoEspectaculoNombre = "";
         BC00077_A2TipoEspectaculoId = new short[1] ;
         BC00077_A12TipoEspectaculoNombre = new string[] {""} ;
         BC00077_A38CantidadEspectaculos = new short[1] ;
         BC00077_n38CantidadEspectaculos = new bool[] {false} ;
         BC00075_A38CantidadEspectaculos = new short[1] ;
         BC00075_n38CantidadEspectaculos = new bool[] {false} ;
         BC00078_A2TipoEspectaculoId = new short[1] ;
         BC00073_A2TipoEspectaculoId = new short[1] ;
         BC00073_A12TipoEspectaculoNombre = new string[] {""} ;
         sMode9 = "";
         BC00072_A2TipoEspectaculoId = new short[1] ;
         BC00072_A12TipoEspectaculoNombre = new string[] {""} ;
         BC00079_A2TipoEspectaculoId = new short[1] ;
         BC000713_A38CantidadEspectaculos = new short[1] ;
         BC000713_n38CantidadEspectaculos = new bool[] {false} ;
         BC000714_A1EspectaculoId = new short[1] ;
         BC000716_A2TipoEspectaculoId = new short[1] ;
         BC000716_A12TipoEspectaculoNombre = new string[] {""} ;
         BC000716_A38CantidadEspectaculos = new short[1] ;
         BC000716_n38CantidadEspectaculos = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipoespectaculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A2TipoEspectaculoId, BC00072_A12TipoEspectaculoNombre
               }
               , new Object[] {
               BC00073_A2TipoEspectaculoId, BC00073_A12TipoEspectaculoNombre
               }
               , new Object[] {
               BC00075_A38CantidadEspectaculos, BC00075_n38CantidadEspectaculos
               }
               , new Object[] {
               BC00077_A2TipoEspectaculoId, BC00077_A12TipoEspectaculoNombre, BC00077_A38CantidadEspectaculos, BC00077_n38CantidadEspectaculos
               }
               , new Object[] {
               BC00078_A2TipoEspectaculoId
               }
               , new Object[] {
               BC00079_A2TipoEspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000713_A38CantidadEspectaculos, BC000713_n38CantidadEspectaculos
               }
               , new Object[] {
               BC000714_A1EspectaculoId
               }
               , new Object[] {
               BC000716_A2TipoEspectaculoId, BC000716_A12TipoEspectaculoNombre, BC000716_A38CantidadEspectaculos, BC000716_n38CantidadEspectaculos
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z2TipoEspectaculoId ;
      private short A2TipoEspectaculoId ;
      private short Z38CantidadEspectaculos ;
      private short A38CantidadEspectaculos ;
      private short RcdFound9 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private bool returnInSub ;
      private bool n38CantidadEspectaculos ;
      private string Z12TipoEspectaculoNombre ;
      private string A12TipoEspectaculoNombre ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00077_A2TipoEspectaculoId ;
      private string[] BC00077_A12TipoEspectaculoNombre ;
      private short[] BC00077_A38CantidadEspectaculos ;
      private bool[] BC00077_n38CantidadEspectaculos ;
      private short[] BC00075_A38CantidadEspectaculos ;
      private bool[] BC00075_n38CantidadEspectaculos ;
      private short[] BC00078_A2TipoEspectaculoId ;
      private short[] BC00073_A2TipoEspectaculoId ;
      private string[] BC00073_A12TipoEspectaculoNombre ;
      private short[] BC00072_A2TipoEspectaculoId ;
      private string[] BC00072_A12TipoEspectaculoNombre ;
      private short[] BC00079_A2TipoEspectaculoId ;
      private short[] BC000713_A38CantidadEspectaculos ;
      private bool[] BC000713_n38CantidadEspectaculos ;
      private short[] BC000714_A1EspectaculoId ;
      private short[] BC000716_A2TipoEspectaculoId ;
      private string[] BC000716_A12TipoEspectaculoNombre ;
      private short[] BC000716_A38CantidadEspectaculos ;
      private bool[] BC000716_n38CantidadEspectaculos ;
      private SdtTipoEspectaculo bcTipoEspectaculo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tipoespectaculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00072;
          prmBC00072 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00073;
          prmBC00073 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00075;
          prmBC00075 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00077;
          prmBC00077 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00078;
          prmBC00078 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00079;
          prmBC00079 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NVarChar,100,0)
          };
          Object[] prmBC000710;
          prmBC000710 = new Object[] {
          new ParDef("@TipoEspectaculoNombre",GXType.NVarChar,100,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000711;
          prmBC000711 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000713;
          prmBC000713 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000714;
          prmBC000714 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000716;
          prmBC000716 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00072", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WITH (UPDLOCK) WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00073", "SELECT [TipoEspectaculoId], [TipoEspectaculoNombre] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00075", "SELECT COALESCE( T1.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T1 WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00077", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre], COALESCE( T2.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM ([TipoEspectaculo] TM1 LEFT JOIN (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T2 ON T2.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY TM1.[TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00078", "SELECT [TipoEspectaculoId] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00079", "INSERT INTO [TipoEspectaculo]([TipoEspectaculoNombre]) VALUES(@TipoEspectaculoNombre); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000710", "UPDATE [TipoEspectaculo] SET [TipoEspectaculoNombre]=@TipoEspectaculoNombre  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmBC000710)
             ,new CursorDef("BC000711", "DELETE FROM [TipoEspectaculo]  WHERE [TipoEspectaculoId] = @TipoEspectaculoId", GxErrorMask.GX_NOMASK,prmBC000711)
             ,new CursorDef("BC000713", "SELECT COALESCE( T1.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T1 WHERE T1.[TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000714", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000714,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000716", "SELECT TM1.[TipoEspectaculoId], TM1.[TipoEspectaculoNombre], COALESCE( T2.[CantidadEspectaculos], 0) AS CantidadEspectaculos FROM ([TipoEspectaculo] TM1 LEFT JOIN (SELECT COUNT(*) AS CantidadEspectaculos, [TipoEspectaculoId] FROM [Espectaculo] GROUP BY [TipoEspectaculoId] ) T2 ON T2.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[TipoEspectaculoId] = @TipoEspectaculoId ORDER BY TM1.[TipoEspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000716,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
