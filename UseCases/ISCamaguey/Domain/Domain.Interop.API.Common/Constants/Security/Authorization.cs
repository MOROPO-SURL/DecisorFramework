using System;
using System.Collections.Generic;
using System.Text;

namespace MOROPO.ISCamaguey.Decisor.Domain.Interop.API.Common.Constants.Security
{
    public static class Authorization
    {
        #region SampleKind
        public const string SampleKindManagementPermissionGroup = "sample-kind-management-permission-group";

        public const string SampleKindViewerPermission = "sample-kind-viewer-permission";
        public const string SampleKindCreatorPermission = "sample-kind-creator-permission";
        public const string SampleKindEditorPermission = "sample-kind-editor-permission";
        public const string SampleKindRemoverPermission = "sample-kind-remover-permission";
        #endregion


        #region Technique
        public const string TechniqueManagementPermissionGroup = "technique-management-permission-group";

        public const string TechniqueViewerPermission = "technique-viewer-permission";
        public const string TechniqueCreatorPermission = "technique-creator-permission";
        public const string TechniqueEditorPermission = "technique-editor-permission";
        public const string TechniqueRemoverPermission = "technique-remover-permission";
        #endregion
    }
}
