using System;
using System.Data;
using JsonApiDotNetCore.Resources.Annotations;
using JsonApiDotNetCore.Serialization.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonApiDotNetCore.Configuration
{
    /// <summary>
    /// Global options that configure the behavior of JsonApiDotNetCore.
    /// </summary>
    public interface IJsonApiOptions
    {
        internal NamingStrategy SerializerNamingStrategy
        {
            get
            {
                var contractResolver = SerializerSettings.ContractResolver as DefaultContractResolver;
                return contractResolver?.NamingStrategy ?? JsonApiOptions.DefaultNamingStrategy;
            }
        }

        /// <summary>
        /// The URL prefix to use for exposed endpoints.
        /// </summary>
        /// <example>
        /// <code>options.Namespace = "api/v1";</code>
        /// </example>
        string Namespace { get; }

        /// <summary>
        /// Specifies the default query string capabilities that can be used on exposed JSON:API attributes. Defaults to <see cref="AttrCapabilities.All" />.
        /// </summary>
        AttrCapabilities DefaultAttrCapabilities { get; }

        /// <summary>
        /// Whether or not <see cref="Exception" /> stack traces should be serialized in <see cref="ErrorMeta" /> objects. False by default.
        /// </summary>
        bool IncludeExceptionStackTraceInErrors { get; }

        /// <summary>
        /// Use relative links for all resources. False by default.
        /// </summary>
        /// <example>
        /// <code>
        /// options.UseRelativeLinks = true;
        /// </code>
        /// <code>
        /// {
        ///   "type": "articles",
        ///   "id": "4309",
        ///   "relationships": {
        ///      "author": {
        ///        "links": {
        ///          "self": "/api/v1/articles/4309/relationships/author",
        ///          "related": "/api/v1/articles/4309/author"
        ///        }
        ///      }
        ///   }
        /// }
        /// </code>
        /// </example>
        bool UseRelativeLinks { get; }

        /// <summary>
        /// Configures which links to show in the <see cref="Serialization.Objects.TopLevelLinks" /> object. Defaults to <see cref="LinkTypes.All" />. This
        /// setting can be overruled per resource type by adding <see cref="ResourceLinksAttribute" /> on the class definition of a resource.
        /// </summary>
        LinkTypes TopLevelLinks { get; }

        /// <summary>
        /// Configures which links to show in the <see cref="Serialization.Objects.ResourceLinks" /> object. Defaults to <see cref="LinkTypes.All" />. This
        /// setting can be overruled per resource type by adding <see cref="ResourceLinksAttribute" /> on the class definition of a resource.
        /// </summary>
        LinkTypes ResourceLinks { get; }

        /// <summary>
        /// Configures which links to show in the <see cref="Serialization.Objects.RelationshipLinks" /> object. Defaults to <see cref="LinkTypes.All" />. This
        /// setting can be overruled for all relationships per resource type by adding <see cref="ResourceLinksAttribute" /> on the class definition of a
        /// resource. This can be further overruled per relationship by setting <see cref="RelationshipAttribute.Links" />.
        /// </summary>
        LinkTypes RelationshipLinks { get; }

        /// <summary>
        /// Whether or not the total resource count should be included in all document-level meta objects. False by default.
        /// </summary>
        bool IncludeTotalResourceCount { get; }

        /// <summary>
        /// The page size (10 by default) that is used when not specified in query string. Set to <c>null</c> to not use paging by default.
        /// </summary>
        PageSize DefaultPageSize { get; }

        /// <summary>
        /// The maximum page size that can be used, or <c>null</c> for unconstrained (default).
        /// </summary>
        PageSize MaximumPageSize { get; }

        /// <summary>
        /// The maximum page number that can be used, or <c>null</c> for unconstrained (default).
        /// </summary>
        PageNumber MaximumPageNumber { get; }

        /// <summary>
        /// Whether or not to enable ASP.NET Core model state validation. False by default.
        /// </summary>
        bool ValidateModelState { get; }

        /// <summary>
        /// Whether or not clients can provide IDs when creating resources. When not allowed, a 403 Forbidden response is returned if a client attempts to create
        /// a resource with a defined ID. False by default.
        /// </summary>
        bool AllowClientGeneratedIds { get; }

        /// <summary>
        /// Whether or not resource hooks are enabled. This is currently an experimental feature and subject to change in future versions. Defaults to False.
        /// </summary>
        public bool EnableResourceHooks { get; }

        /// <summary>
        /// Whether or not database values should be included by default for resource hooks. Ignored if EnableResourceHooks is set to false. False by default.
        /// </summary>
        bool LoadDatabaseValues { get; }

        /// <summary>
        /// Whether or not to produce an error on unknown query string parameters. False by default.
        /// </summary>
        bool AllowUnknownQueryStringParameters { get; }

        /// <summary>
        /// Determines whether legacy filter notation in query strings, such as =eq:, =like:, and =in: is enabled. False by default.
        /// </summary>
        bool EnableLegacyFilterNotation { get; }

        /// <summary>
        /// Determines whether the <see cref="JsonSerializerSettings.NullValueHandling" /> serialization setting can be controlled using a query string
        /// parameter. False by default.
        /// </summary>
        bool AllowQueryStringOverrideForSerializerNullValueHandling { get; }

        /// <summary>
        /// Determines whether the <see cref="JsonSerializerSettings.DefaultValueHandling" /> serialization setting can be controlled using a query string
        /// parameter. False by default.
        /// </summary>
        bool AllowQueryStringOverrideForSerializerDefaultValueHandling { get; }

        /// <summary>
        /// Controls how many levels deep includes are allowed to be nested. For example, MaximumIncludeDepth=1 would allow ?include=articles but not
        /// ?include=articles.revisions. <c>null</c> by default, which means unconstrained.
        /// </summary>
        int? MaximumIncludeDepth { get; }

        /// <summary>
        /// Limits the maximum number of operations allowed per atomic:operations request. Defaults to 10. Set to <c>null</c> for unlimited.
        /// </summary>
        int? MaximumOperationsPerRequest { get; }

        /// <summary>
        /// Enables to override the default isolation level for database transactions, enabling to balance between consistency and performance. Defaults to
        /// <c>null</c>, which leaves this up to Entity Framework Core to choose (and then it varies per database provider).
        /// </summary>
        IsolationLevel? TransactionIsolationLevel { get; }

        /// <summary>
        /// Specifies the settings that are used by the <see cref="JsonSerializer" />. Note that at some places a few settings are ignored, to ensure JSON:API
        /// spec compliance.
        /// <example>
        /// The next example changes the naming convention to kebab casing.
        /// <code><![CDATA[
        /// options.SerializerSettings.ContractResolver = new DefaultContractResolver
        /// {
        ///     NamingStrategy = new KebabCaseNamingStrategy()
        /// };
        /// ]]></code>
        /// </example>
        /// </summary>
        JsonSerializerSettings SerializerSettings { get; }
    }
}
