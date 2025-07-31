using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Constants.Security
{
    public static class Authorization
    {
        #region Purchase
        public const string PurchaseManagementPermissionGroup = "purchase-management-permission-group";

        public const string PurchaseViewerPermission = "purchase-viewer-permission";
        public const string PurchaseCreatorPermission = "purchase-creator-permission";
        public const string PurchaseEditorPermission = "purchase-editor-permission";
        public const string PurchaseRemoverPermission = "purchase-remover-permission";

        public const string PurchaseZoneViewerPermission = "purchase-zone-viewer-permission";
        public const string PurchaseZoneCreatorPermission = "purchase-zone-creator-permission";
        public const string PurchaseZoneEditorPermission = "purchase-zone-editor-permission";
        public const string PurchaseZoneRemoverPermission = "purchase-zone-remover-permission";

        public const string PurchaseSpentPermission = "purchase-spent-viewer-permission";
        public const string PurchaseSpentCreatorPermission = "purchase-spent-creator-permission";
        public const string PurchaseSpentEditorPermission = "purchase-spent-editor-permission";
        public const string PurchaseSpentRemoverPermission = "purchase-spent-remover-permission";
        #endregion
    }
}
