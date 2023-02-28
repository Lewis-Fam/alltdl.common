namespace alltdl.Constants
{
    [Serializable]
    public enum ExecutionSection
    {
        None,

        DetectExecutionPlan,

        DiskValidations,

        PrerequisiteItemsToUpdate,

        Prerequisites,

        DirectoriesToCreate,

        PackagedItemsToCopy,

        ItemsToBackupBeforeUninstall,

        ItemsToBackupBeforeInstall,

        ItemsToRestoreAfterInstall,

        ItemsToDeleteAfterInstall,

        ItemsToDeleteAfterUninstall,

        PreInstallProcesses,

        PreUpgradeProcesses,

        PrePatchProcesses,

        PreRecoveryProcesses,

        ProcessesToRunAfterDatabaseRecovery,

        ProcessesToRunAfterDatabaseUpgrade,

        PreUninstallProcesses,

        InstallItemsToRun,

        UpgradeItemsToRun,

        PatchItemsToRun,

        UninstallItemsToRun,

        ProcessesToStopBeforeInstall,

        ProcessesToStopBeforeUninstall,

        ProcessesToStopBeforePostProcesses,

        ProcessesToStop,

        ServicesToStopBeforeInstall,

        ServicesToStopBeforeUninstall,

        ServicesToStopBeforePostProcesses,

        ServicesToStartBeforePostProcesses,

        ServicesToStartAfterPostProcesses,

        ServicesToStop,

        ConfigureServices,

        DatabasesToRestoreBeforeRecovery,

        DatabasesToRestoreBeforeUpgrade,

        DatabasesToBackupBeforeUpgrade,

        DatabasesToBackupBeforeUninstall,

        DatabasesToBackupAfterInstall,

        LinkDatabaseNamesFromRecovery,

        LinkDatabaseNamesFromUpgrade,

        DatabaseDelete,

        FilesToUpdateBeforePreInstallProcesses,

        FilesToUpdateBeforePreUpgradeProcesses,

        FilesToUpdateBeforePreRecoveryProcesses,

        FilesToUpdateBeforePrePatchProcesses,

        FilesToUpdateAfterPreInstallProcesses,

        FilesToUpdateAfterPreUpgradeProcesses,

        FilesToUpdateAfterPreRecoveryProcesses,

        FilesToUpdateAfterPrePatchProcesses,

        FilesToUpdateAfterInstall,

        FilesToUpdateAfterUpgrade,

        FilesToUpdateAfterRecovery,

        FilesToUpdateAfterPatchInstall,

        PostInstallProcesses,

        PostUpgradeProcesses,

        PostPatchProcesses,

        PostRecoveryProcesses,

        PostUninstallProcesses,

        FilesToUpdateAfterPostInstallProcesses,

        FilesToUpdateAfterPostUpgradeProcesses,

        FilesToUpdateAfterPostRecoveryProcesses,

        FilesToUpdateAfterPostPatchProcesses,

        DeleteAccountsAfterUninstall,

        DeleteAccountsAfterInstall,

        DeletePendingFileRenameOperations,

        CreateDesktopShorcuts
    }
}