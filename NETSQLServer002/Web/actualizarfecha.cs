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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class actualizarfecha : GXProcedure
   {
      public actualizarfecha( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("TallerGeneXus", true);
      }

      public actualizarfecha( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_VentaId )
      {
         this.AV8VentaId = aP0_VentaId;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( short aP0_VentaId )
      {
         this.AV8VentaId = aP0_VentaId;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P000I2 */
         pr_default.execute(0, new Object[] {AV8VentaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A8VentaId = P000I2_A8VentaId[0];
            A23VentaHoraFecha = P000I2_A23VentaHoraFecha[0];
            A23VentaHoraFecha = DateTimeUtil.Now( context);
            /* Using cursor P000I3 */
            pr_default.execute(1, new Object[] {A23VentaHoraFecha, A8VentaId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Venta");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("actualizarfecha",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P000I2_A8VentaId = new short[1] ;
         P000I2_A23VentaHoraFecha = new DateTime[] {DateTime.MinValue} ;
         A23VentaHoraFecha = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actualizarfecha__default(),
            new Object[][] {
                new Object[] {
               P000I2_A8VentaId, P000I2_A23VentaHoraFecha
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8VentaId ;
      private short A8VentaId ;
      private DateTime A23VentaHoraFecha ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A8VentaId ;
      private DateTime[] P000I2_A23VentaHoraFecha ;
   }

   public class actualizarfecha__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          new ParDef("@AV8VentaId",GXType.Int16,4,0)
          };
          Object[] prmP000I3;
          prmP000I3 = new Object[] {
          new ParDef("@VentaHoraFecha",GXType.DateTime,8,5) ,
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT [VentaId], [VentaHoraFecha] FROM [Venta] WITH (UPDLOCK) WHERE [VentaId] = @AV8VentaId ORDER BY [VentaId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000I3", "UPDATE [Venta] SET [VentaHoraFecha]=@VentaHoraFecha  WHERE [VentaId] = @VentaId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000I3)
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
                return;
       }
    }

 }

}
