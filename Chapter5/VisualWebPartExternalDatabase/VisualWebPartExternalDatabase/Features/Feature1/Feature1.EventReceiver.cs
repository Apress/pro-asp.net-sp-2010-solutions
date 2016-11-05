using System;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace VisualWebPartExternalDatabase.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("5575c909-06ff-4d81-884c-e5524d76f5e5")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        //public override void FeatureActivated(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


         public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = new SPSite("http://dave-laptop3:100/sites/davehome").WebApplication;

            SPWebConfigModification mod = new SPWebConfigModification("connectionStrings", "configuration");
            mod.Owner = "VWPAdventureWorks";
            mod.Sequence = 0;
            mod.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureSection;
            webApp.WebConfigModifications.Add(mod);

            SPWebConfigModification mod1 = new SPWebConfigModification("add", "configuration/connectionStrings");
            mod1.Owner = "VWPAdventureWorks";
            mod1.Sequence = 0;

            mod1.Type = SPWebConfigModification.SPWebConfigModificationType.EnsureChildNode;
            mod1.Value = "<add name=\"AdventureWorks\" connectionString=\"data source=DAVE-LAPTOP3;Integrated Security=SSPI;Initial Catalog=AdventureWorksLT2008R2\" providerName=\"System.Data.SqlClient\" />";

            webApp.WebConfigModifications.Add(mod1);
            webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
            webApp.Update(); 
        }


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

         public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
         {
             SPWebApplication webApp = new SPSite("http://dave-laptop3/sites/davehome").WebApplication;
             Collection<SPWebConfigModification> collection = webApp.WebConfigModifications;

             int iStartCount = collection.Count;

             // Remove any modifications that were originally created by the owner.
             for (int c = iStartCount - 1; c >= 0; c--)
             {
                 SPWebConfigModification configMod = collection[c];

                 if (configMod.Owner == "VWPAdventureWorks")
                     collection.Remove(configMod);
             }

             // Apply changes only if any items were removed.
             if (iStartCount > collection.Count)
             {
                 webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
                 webApp.Update();
             }

         }

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}


    }
}
