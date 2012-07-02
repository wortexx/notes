﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Infrastructure
{
    public class InfrastructureInstaller : IWindsorInstaller
    {
        #region Implementation of IWindsorInstaller

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<PersistenceFacility>();
        }

        #endregion
    }
}