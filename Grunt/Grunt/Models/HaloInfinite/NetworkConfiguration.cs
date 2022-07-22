// <copyright file="NetworkConfiguration.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class NetworkConfiguration
    {
        public int HighlightedHopperSendTimeMs { get; set; }
        public float prioritiyBaseNonPlayerMotion { get; set; }
        public int PriorityMaxThreshold { get; set; }
        public float PriorityMax { get; set; }
        public float PriorityMediumBase { get; set; }
        public float PriorityMediumRelevanceScale { get; set; }
        public float PriorityMinimumBase { get; set; }
        public float PriorityMinimumRelevanceScale { get; set; }
        public int PlayerNotificationUnlistenTimeoutSecs { get; set; }
        public int GriefIdleControllerCenterThreshold { get; set; }
        public int GriefIdleControllerHysteresisThreshold { get; set; }
        public int MaxTimeToJoinUDPSessionAfterAppearingInRosterSeconds { get; set; }
        public bool TransportIgnoreNetworkStatusChanged { get; set; }
        public int QosMaxNumRetriesResolveDnsName { get; set; }
        public int QosMaxNumRetriesValidateHostAddress { get; set; }
        public int QosTimeBetweenPacketSendsMs { get; set; }
        public int QosMaxNumRetriesToSendPacket { get; set; }
        public int QosPacketRecvTimeoutMs { get; set; }
        public int QosMaxNumRetriesOnPacketRecvTimeout { get; set; }
        public int QosPacketBlackholeTimeoutMs { get; set; }
        public float QosFractionMinPacketsOnPacketRecvTimeout { get; set; }
        public bool QosShouldUseNetworkPollster { get; set; }
        public int QosMaxNumTransportResets { get; set; }
        public float TeamBalancerMinMMR { get; set; }
        public float TeamBalancerMaxMMR { get; set; }
        public int TeamBalancerMMRQuantizationSteps { get; set; }
        public float TeamBalancerMMRExponent { get; set; }
        public int MaxTimeToJoinUDPSessionAfterAppearingInRosterDuringJIPSeconds { get; set; }
        public int HostTeardownTimeoutSeconds { get; set; }
        public int LobbyConnectionBlockingSpinnerMaxTimeMSec { get; set; }
        public int MinimumTimeBetweenLowPriStateUpdatesMsec { get; set; }
        public int LobbyConnectionDelayOnInitialJoinMsec { get; set; }
        public int IdleSecondsBeforeBootCustomGames { get; set; }
        public int IdleSecondsBeforeBootCampaign { get; set; }
        public bool ChatTeardownOnEnteringGameplay { get; set; }
        public bool ChatTeardownOnExitingGameplay { get; set; }
        public int MainThreadHitchDetectionInReleaseServerThresholdMs { get; set; }
        public int UDPSafetyPacketMaximumInterval { get; set; }
        public int TeamBalancerBruteForceMaxPlayers { get; set; }
        public int RequisitionCatalogNormalRefreshSeconds { get; set; }
        public int RequisitionCatalogSecondsBetweenRetries { get; set; }
        public int RequisitionCatalogRetryCount { get; set; }
        public int RequisitionCatalogSecondsBetweenRetryPeriods { get; set; }
        public int RequisitionInventoryNormalRefreshSeconds { get; set; }
        public int RequisitionInventorySecondsBetweenRetry { get; set; }
        public int RequisitionInventoryRetryCount { get; set; }
        public int RequisitionInventorySecondsBetweenRetryPeriods { get; set; }
        public bool RogueClientsTriggerImmediateHeartbeatsRogueClientsTriggerImmediateHeartbeats { get; set; }
        public int MaxTimeToWaitForRogueClientsToAppearInRosterMs { get; set; }
        public int UDPInitialAckTimeoutMsec { get; set; }
        public int UDPBandwidthControlMaximumRttForAutomaticCongestionMsec { get; set; }
        public float UDPBandwidthControlCongestingRttPermittedDeviationsFromLockedRtt { get; set; }
        public float UDPBandwidthControlDriftWindowLatencyDeviationMultiplier { get; set; }
        public int UDPBandwidthControlThrottleCongestedStreamBandwidthMultiplier { get; set; }
        public int UDPBandwidthControlStreamMaximumBandwidthMaximumDelta { get; set; }
        public int UDPBandwidthControlStreamMaximumBandwidthSkipMax { get; set; }
        public int UDPBandwidthControlStreamProbeFailureLimit { get; set; }
        public int UDPBandwidthControlStreamRetryGrowthIntervalMsec { get; set; }
        public int QoSRedoAllResultsTimeMs { get; set; }
        public int UDPStreamMinimumBps { get; set; }
        public bool UDPBandwidthControlEnabled { get; set; }
        public int UDPBandwidthControlQueryTimeMinimumMs { get; set; }
        public int UDPBandwidthControlQueryTimeAfterDelayMs { get; set; }
        public int UDPBandwidthControlProbeSettleTimeMs { get; set; }
        public int UDPBandwidthControlRecoverMinimumTimeMs { get; set; }
        public int UDPBandwidthControlThrottleMinimumRollbackMs { get; set; }
        public float UDPBandwidthControlProbeGrowthRate { get; set; }
        public int UDPPollsterHeartbeatTimeoutMs { get; set; }
        public int UDPBandwidthControlMinPacketSize { get; set; }
        public int UDPConnectRequestTimeoutMs { get; set; }
        public int UDPEstablishTimeoutMs { get; set; }
        public int UDPSessionJoinInitialUpdateTimeoutMs { get; set; }
        public int SimulationJoinTimeoutMs { get; set; }
        public int SimulationHostJoinMinimumWaitTimeMs { get; set; }
        public int SimulationHostJoinTimeoutMs { get; set; }
        public int SimulationJoinTotalWaitTimeoutMs { get; set; }
        public int SimulationWaitForAllClientActivationTimeoutMs { get; set; }
        public int SimulationChangingStateStartPauseTimeoutMs { get; set; }
        public int SimulationChangingStateEndPauseTimeoutMs { get; set; }
        public int UDPConnectionActiveSendTimeoutMs { get; set; }
        public int UDPConnectionDropMinimumActiveTimeMs { get; set; }
        public bool UDPUseEphemeralPort { get; set; }
        public int UgcMaxItemCountGameVariant { get; set; }
        public int UgcMaxItemCountMapVariant { get; set; }
        public int UgcMaxItemCountScreenshot { get; set; }
        public int UgcMaxItemCountBookmark { get; set; }
        public int UgcMaxItemCountForgeObjectGroup { get; set; }
        public int UgcMaxItemCountFilm { get; set; }
        public int UgcItemCountRetryMs { get; set; }
        public int UgcItemCountRetryCount { get; set; }
        public int UgcItemCountRetryPauseSecs { get; set; }
        public int IdleSecondsBeforeBootForge { get; set; }
        public int ForceHopperRefreshTimeMinutes { get; set; }
        public int TimeToWaitBeforeGameSessionGrainStateValidation { get; set; }
        public bool EnableExitExperienceFailureTelemetry { get; set; }
        public bool UDPBandwidthControlThrottleAllowedOnPacketLoss { get; set; }
        public bool CellRecordProjectileDiscrepancies { get; set; }
        public int CellRecordSimulationWarpClientDelayInSeconds { get; set; }
        public int CellRecordSimulationWarpHostDelayInSeconds { get; set; }
        public int CellSimulationHistogramLengthInFrames { get; set; }
        public float CellSimulationHistogramThresholdInPct { get; set; }
        public bool AdjustFilmPlaybackSpeed { get; set; }
        public bool InputPollingOnSeparateThread { get; set; }
        public float CellSimulationWeaponAgeMispredictThreshold { get; set; }
        public float CellSimulationProjectileCreationDelayThresholdInSeconds { get; set; }
        public int QoSBadPingLatencyThresholdMsec { get; set; }
        public bool Matchmaking2015Enabled { get; set; }
        public float CellSimulationBlendOrientationDeltaThreshold { get; set; }
        public float CellSimulationBlendPositionDeltaThreshold { get; set; }
        public float CellSimulationNudgeLinearVelocityDeltaThreshold { get; set; }
        public float CellSimulationNudgeAngularVelocityDeltaThreshold { get; set; }
        public int CellSimulationLoadedRoundsMispredictThreshold { get; set; }
        public int CellSimulationInventoryRoundsMispredictThreshold { get; set; }
        public float CellSimulationPickupDelayThresholdInSeconds { get; set; }
        public float CellSimulationGameTimeMissThresholdInSeconds { get; set; }
        public float CellPerformanceLatencyThresholdMS { get; set; }
        public int CellPerformanceLatencyBelowThresholdTimeoutMS { get; set; }
        public int CellPerformanceLatencyTrackedTimeForSendMS { get; set; }
        public int CellPerformanceLatencyMaxEventsToSend { get; set; }
        public float TotalMemoryUsagePollIntervalInSeconds { get; set; }
        public float TotalMemoryUsageUpdateIntervalInSeconds { get; set; }
        public int CellPlayerStatusTelemetryUpdateInterval { get; set; }
        public int ReadyRoomTimerDurationSeconds { get; set; }
        public float SimulationPauseGameRequiredMachinesFraction { get; set; }
        public float SimulationJoinActivationBlockingMachinesFraction { get; set; }
        public int PresenceRefreshTimeSeconds { get; set; }
    }

}
