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
   public class tipoespectaculo_dataprovider : GXProcedure
   {
      public tipoespectaculo_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public tipoespectaculo_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "TallerGeneXus") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtTipoEspectaculo> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtTipoEspectaculo>( context, "TipoEspectaculo", "TallerGeneXus") ;
         SubmitImpl();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculonombre = "Obra de teatro";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculonombre = "Concierto";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculonombre = "Circo";
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         Gxm2rootcol.Add(Gxm1tipoespectaculo, 0);
         Gxm1tipoespectaculo.gxTpr_Tipoespectaculonombre = "Deporte";
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
         Gxm1tipoespectaculo = new SdtTipoEspectaculo(context);
         /* GeneXus formulas. */
      }

      private GXBCCollection<SdtTipoEspectaculo> Gxm2rootcol ;
      private SdtTipoEspectaculo Gxm1tipoespectaculo ;
      private GXBCCollection<SdtTipoEspectaculo> aP0_Gxm2rootcol ;
   }

}
