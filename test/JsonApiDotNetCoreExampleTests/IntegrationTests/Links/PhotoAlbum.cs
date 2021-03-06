using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.Links
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public sealed class PhotoAlbum : Identifiable<Guid>
    {
        [Attr]
        public string Name { get; set; }

        [HasMany]
        public ISet<Photo> Photos { get; set; }
    }
}
