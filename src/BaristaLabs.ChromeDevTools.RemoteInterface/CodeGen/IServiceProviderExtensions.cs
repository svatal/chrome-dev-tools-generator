﻿namespace BaristaLabs.ChromeDevTools.RemoteInterface.CodeGen
{
    using BaristaLabs.ChromeDevTools.RemoteInterface.ProtocolDefinition;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class IServiceProviderExtensions
    {
        /// <summary>
        /// Adds a pre-defined set of code generator services to provide Chrome Remote Interface generation.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IServiceCollection AddCodeGenerationServices(this IServiceCollection serviceCollection, CodeGenerationSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            return serviceCollection
                .AddSingleton(settings)
                .AddSingleton<TemplatesManager>()
                .AddSingleton<ICodeGenerator<ProtocolDefinition>>((sp) => new ProtocolGenerator(sp))
                .AddSingleton<ICodeGenerator<DomainDefinition>>((sp) => new DomainGenerator(sp))
                .AddSingleton<ICodeGenerator<TypeDefinition>>((sp) => new TypeGenerator(sp))
                .AddSingleton<ICodeGenerator<CommandDefinition>>((sp) => new CommandGenerator(sp))
                .AddSingleton<ICodeGenerator<EventDefinition>>((sp) => new EventGenerator(sp));
        }
    }
}
