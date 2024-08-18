using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pais_dataprovider : GXProcedure
   {
      public pais_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public pais_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "TallerGeneXus") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "TallerGeneXus") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Uruguay";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Brasil";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Argentina";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "México";
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisnombre = "Chile";
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         Gxm1pais = new SdtPais(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtPais> Gxm2rootcol ;
      private SdtPais Gxm1pais ;
      private GXBCCollection<SdtPais> aP0_Gxm2rootcol ;
   }

}
