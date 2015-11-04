---
title: Installing The Platform Components Manually without Platform Installer
summary: 'Guidance on how to install the platform components'
tags: [Platform, Installation, Offline]
---

The [Platform Installer](/platform/installer) handles installing pre-requisites for NServiceBus and the Platform products.  This guide details how to install to achieve the same results as the Platform Installer on a computer that does not have the required Internet connectivity.


## .Net Prerequisite Version

The Particular platform products require [.Net 4.5.1](https://www.microsoft.com/en-us/download/details.aspx?id=40779). Before proceeding please ensure that this version of .Net is available on the system you are setting up. More detailed information about .NET 4.5.1 can be found on the [.NET Blog](http://blogs.msdn.com/b/dotnet/archive/2013/12/09/the-net-framework-4-5-1-is-now-available-on-windows-update-and-wsus.aspx). 

Note: Windows 8.1 and Windows 2012 R2 or greater already ship with this version so no action is required on these products.


##  Platform Installer Components

The Platform Installer installs 4 component parts:

- NServiceBus Prerequisities
- ServiceControl
- ServicePulse
- ServiceInsight

Each of these will be detailed below:


### NServiceBus Prerequistes

The NServiceBus Prerequisites option in the Platform Install configures the system to run NServiceBus endpoints using Microsoft Message Queuing(MSMQ) by doing the following:

- Adds, configures and starts the MSMQ service.
- Configures and starts the Microsoft Distributed Co-ordinator Service
- Adds NServiceBus Performance Counters

These actions are available via [NServicebus PowerShell Module](https://github.com/Particular/NServiceBus.PowerShell/releases/latest).  This module is available as standalone installation.  Once the module is installed, open a PowerShell prompt as a Administrator and issue the following commands:

```bat
Import-Module NServiceBus.PowerShell
Install-NServiceBusDTC
Install-NServiceBusMSMQ
Install-NServiceBusPerformanceCounters
```


### ServiceControl 

This MSI can be downloaded directly from here: [ServiceControl Releases](https://github.com/Particular/ServiceControl/releases/latest).


### ServiceInsight

This MSI can be downloaded directly from here: [ServiceInsight Releases](https://github.com/Particular/ServiceInsight/releases/latest).


### ServicePulse

This MSI can be downloaded directly from here: [ServicePulse Releases](https://github.com/Particular/ServicePulse/releases/latest).

WARN: ServiceMatrix has been discontinued and is no longer actively supported. We are currently investing our efforts to provide routing visualization for existing solutions as well. For more details, please download the [routing visualization tool](https://github.com/ParticularLabs/RoutingVisualization). You will still be able to install the ServiceMatrix extensions directly from the Visual Studio Gallery until the end of 2015. 
