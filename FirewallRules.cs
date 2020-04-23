using NetFwTypeLib;
using SoloMatchmaking;
using System;
using System.Text;

class FirewallRules {
    private static FirewallRules ClassInstance = new FirewallRules();
    public static FirewallRules GetInstance() {
        return ClassInstance;
    }

    private static volatile string _Destiny2RulesName = "Destiny2Solo"; // Name
    private static volatile string _Destiny2Ports = "3097,27000-27200"; // Ports
    private static volatile bool _Destiny2OutTCPRuleCreated = false;    // OutTCP Created
    private static volatile bool _Destiny2OutUDPRuleCreated = false;    // OutUDP Created
    private static volatile bool _Destiny2InTCPRuleCreated = false;     // InTCP Created
    private static volatile bool _Destiny2InUDPRuleCreated = false;     // InUDP Created
    private static volatile bool _Destiny2OutTCPEnabled = false;        // OutTCP Enabled
    private static volatile bool _Destiny2OutUDPEnabled = false;        // OutUDP Enabled
    private static volatile bool _Destiny2InTCPEnabled = false;         // InTCP Enabled
    private static volatile bool _Destiny2InUDPEnabled = false;         // InUDP Enabled
    private static volatile bool _Destiny2RulesAcitvated = false;       // Rules activated

    private static volatile string _RockstarGamesRulesName = "RockstarSolo";        // Name
    private static volatile string _RockstarGamesPorts = "6672";                    // Ports
    private static volatile bool _RockstarGamesOutUDPRuleCreated = false;           // OutUDP Created
    private static volatile bool _RockstarGamesInUDPRuleCreated = false;            // InUDP Created
    private static volatile bool _RockstarGamesOutUDPEnabled = false;               // OutUDP Enabled
    private static volatile bool _RockstarGamesInUDPEnabled = false;                // InUDP Enabled
    private static volatile bool _RockstarGamesRulesActivated = false;              // Rules activated

    public string Destiny2RulesName {
        get { return _Destiny2RulesName; }
        set { _Destiny2RulesName = value; }
    }
    public string Destiny2Ports {
        get { return _Destiny2Ports; }
        set { _Destiny2Ports = value; }
    }
    public bool Destiny2OutTCPRuleCreated {
        get { return _Destiny2OutTCPRuleCreated; }
        set { _Destiny2OutTCPRuleCreated = value; }
    }
    public bool Destiny2OutUDPRuleCreated {
        get { return _Destiny2OutUDPRuleCreated; }
        set { _Destiny2OutUDPRuleCreated = value; }
    }
    public bool Destiny2InTCPRuleCreated {
        get { return _Destiny2InTCPRuleCreated; }
        set { _Destiny2InTCPRuleCreated = value; }
    }
    public bool Destiny2InUDPRuleCreated {
        get { return _Destiny2InUDPRuleCreated; }
        set { _Destiny2InUDPRuleCreated = value; }
    }
    public bool Destiny2OutTCPEnabled {
        get { return _Destiny2OutTCPEnabled; }
        set { _Destiny2OutTCPEnabled = value; }
    }
    public bool Destiny2OutUDPEnabled {
        get { return _Destiny2OutUDPEnabled; }
        set { _Destiny2OutUDPEnabled = value; }
    }
    public bool Destiny2InTCPEnabled {
        get { return _Destiny2InTCPEnabled; }
        set { _Destiny2InTCPEnabled = value; }
    }
    public bool Destiny2InUDPEnabled {
        get { return _Destiny2InUDPEnabled; }
        set { _Destiny2InUDPEnabled = value; }
    }
    public bool Destiny2RulesActivated {
        get { return _Destiny2RulesAcitvated; }
        set { _Destiny2RulesAcitvated = value; }
    }

    public string RockstarGamesRulesName {
        get { return _RockstarGamesRulesName; }
        set { _RockstarGamesRulesName = value; }
    }
    public string RockstarGamesPorts {
        get { return _RockstarGamesPorts; }
        set { _RockstarGamesPorts = value; }
    }
    public bool RockstarGamesOutUDPRuleCreated {
        get { return _RockstarGamesOutUDPRuleCreated; }
        set { _RockstarGamesOutUDPRuleCreated = value; }
    }
    public bool RockstarGamesInUDPRuleCreated {
        get { return _RockstarGamesInUDPRuleCreated; }
        set { _RockstarGamesInUDPRuleCreated = value; }
    }
    public bool RockstarGamesOutUDPEnabled {
        get { return _RockstarGamesOutUDPEnabled; }
        set { _RockstarGamesOutUDPEnabled = value; }
    }
    public bool RockstarGamesInUDPEnabled {
        get { return _RockstarGamesInUDPEnabled; }
        set { _RockstarGamesInUDPEnabled = value; }
    }
    public bool RockstarGamesRulesActivated {
        get { return _RockstarGamesRulesActivated; }
        set { _RockstarGamesRulesActivated = value; }
    }

    public void CheckRules() {
        Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

        foreach (INetFwRule FoundRule in fwPolicy.Rules) {
            if (FoundRule.Name == _Destiny2RulesName + "OutTCP") {
                _Destiny2OutTCPRuleCreated = true;
                _Destiny2OutTCPEnabled = FoundRule.Enabled;
                continue;
            }
            else if (FoundRule.Name == _Destiny2RulesName + "OutUDP") {
                _Destiny2OutUDPRuleCreated = true;
                _Destiny2OutUDPEnabled = FoundRule.Enabled;
                continue;
            }
            else if (FoundRule.Name == _Destiny2RulesName + "InTCP") {
                _Destiny2InTCPRuleCreated = true;
                _Destiny2InTCPEnabled = FoundRule.Enabled;
                continue;
            }
            else if (FoundRule.Name == _Destiny2RulesName + "InUDP") {
                _Destiny2InUDPRuleCreated = true;
                _Destiny2InUDPEnabled = FoundRule.Enabled;
                continue;
            }

            else if (FoundRule.Name == _RockstarGamesRulesName + "OutUDP") {
                _RockstarGamesOutUDPRuleCreated = true;
                _RockstarGamesOutUDPEnabled = FoundRule.Enabled;
                continue;
            }
            else if (FoundRule.Name == _RockstarGamesRulesName + "InUDP") {
                _RockstarGamesInUDPRuleCreated = true;
                _RockstarGamesInUDPEnabled = FoundRule.Enabled;
                continue;
            }
        }

        if (_Destiny2OutTCPEnabled || _Destiny2OutUDPEnabled || _Destiny2InTCPEnabled || _Destiny2InUDPEnabled) {
            _Destiny2RulesAcitvated = true;
        }
        else {
            _Destiny2RulesAcitvated = false;
        }

        if (_RockstarGamesOutUDPEnabled || _RockstarGamesInUDPEnabled) {
            _RockstarGamesRulesActivated = true;
        }
        else {
            _RockstarGamesRulesActivated = false;
        }
    }

    public bool CreateDestinyRule(int RuleType) {
        try {

            #region Rule buffer
            INetFwRule2 outTCP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 outUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 inTCP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 inUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            // =============== Out TCP ================ \\

            outTCP.Name = _Destiny2RulesName + "OutTCP";
            if (Configuration.Default.DestinySpecifyApplication) {
                outTCP.ApplicationName = Configuration.Default.DestinyExecutable;
            }
            outTCP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            outTCP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            outTCP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            outTCP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            outTCP.Protocol = PortProtocol.TCP;
            if (Configuration.Default.DestinyBlockLocalPorts) {
                outTCP.LocalPorts = _Destiny2Ports;
            }
            if (Configuration.Default.DestinyBlockRemotePorts) {
                outTCP.RemotePorts = _Destiny2Ports;
            }
            outTCP.InterfaceTypes = "All";
            outTCP.Enabled = true;
            Console.WriteLine("Destiny 2 outTCP created");

            // =============== Out UDP ================ \\

            outUDP.Name = _Destiny2RulesName + "OutUDP";
            if (Configuration.Default.DestinySpecifyApplication) {
                outUDP.ApplicationName = Configuration.Default.DestinyExecutable;
            }
            outUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            outUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            outUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            outUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            outUDP.Protocol = PortProtocol.UDP;
            if (Configuration.Default.DestinyBlockLocalPorts) {
                outUDP.LocalPorts = _Destiny2Ports;
            }
            if (Configuration.Default.DestinyBlockRemotePorts) {
                outUDP.RemotePorts = _Destiny2Ports;
            }
            outUDP.InterfaceTypes = "All";
            outUDP.Enabled = true;
            Console.WriteLine("Destiny 2 outUDP created");

            // =============== In  TCP ================ \\

            inTCP.Name = _Destiny2RulesName + "InTCP";
            if (Configuration.Default.DestinySpecifyApplication) {
                inTCP.ApplicationName = Configuration.Default.DestinyExecutable;
            }
            inTCP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            inTCP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            inTCP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            inTCP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            inTCP.Protocol = PortProtocol.TCP;
            if (Configuration.Default.DestinyBlockLocalPorts) {
                inTCP.LocalPorts = _Destiny2Ports;
            }
            if (Configuration.Default.DestinyBlockRemotePorts) {
                inTCP.RemotePorts = _Destiny2Ports;
            }
            inTCP.InterfaceTypes = "All";
            inTCP.Enabled = true;
            Console.WriteLine("Destiny 2 inTCP created");

            // =============== In  UDP ================ \\

            inUDP.Name = _Destiny2RulesName + "InUDP";
            if (Configuration.Default.DestinySpecifyApplication) {
                inUDP.ApplicationName = Configuration.Default.DestinyExecutable;
            }
            inUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            inUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            inUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            inUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            inUDP.Protocol = PortProtocol.UDP;
            if (Configuration.Default.DestinyBlockLocalPorts) {
                inUDP.LocalPorts = _Destiny2Ports;
            }
            if (Configuration.Default.DestinyBlockRemotePorts) {
                inUDP.RemotePorts = _Destiny2Ports;
            }
            inUDP.InterfaceTypes = "All";
            inUDP.Enabled = true;
            Console.WriteLine("Destiny 2 inUDP created");
            #endregion

            switch (RuleType) {
                #region All Rules
                case -1:
                    firewallPolicy.Rules.Add(outTCP);
                    _Destiny2OutTCPRuleCreated = true;
                    _Destiny2OutTCPEnabled = true;
                    Console.WriteLine("Destiny 2 added OutTCP to the firewall");
                    firewallPolicy.Rules.Add(outUDP);
                    _Destiny2OutUDPRuleCreated = true;
                    _Destiny2OutUDPEnabled = true;
                    Console.WriteLine("Destiny 2 added OutUDP to the firewall");
                    firewallPolicy.Rules.Add(inTCP);
                    _Destiny2InTCPRuleCreated = true;
                    _Destiny2InTCPEnabled = true;
                    Console.WriteLine("Destiny 2 added InTCP to the firewall");
                    firewallPolicy.Rules.Add(inUDP);
                    _Destiny2InUDPRuleCreated = true;
                    _Destiny2InUDPEnabled = true;
                    Console.WriteLine("Destiny 2 added InUDP to the firewall");
                    return true;
                #endregion
                #region OutTCP
                case 0:
                    firewallPolicy.Rules.Add(outTCP);
                    _Destiny2OutTCPRuleCreated = true;
                    _Destiny2OutTCPEnabled = true;
                    Console.WriteLine("Destiny 2 added OutTCP to the firewall");
                    return true;
                #endregion
                #region OutUDP
                case 1:
                    firewallPolicy.Rules.Add(outUDP);
                    _Destiny2OutUDPRuleCreated = true;
                    _Destiny2OutUDPEnabled = true;
                    Console.WriteLine("Destiny 2 added OutUDP to the firewall");
                    return true;
                #endregion
                #region InTCP
                case 2:
                    firewallPolicy.Rules.Add(inTCP);
                    _Destiny2InTCPRuleCreated = true;
                    _Destiny2InTCPEnabled = true;
                    Console.WriteLine("Destiny 2 added InTCP to the firewall");
                    return true;
                #endregion
                #region InUDP
                case 3:
                    firewallPolicy.Rules.Add(inUDP);
                    _Destiny2InUDPRuleCreated = true;
                    _Destiny2InUDPEnabled = true;
                    Console.WriteLine("Destiny 2 added InUDP to the firewall");
                    return true;
                #endregion
                default:
                    return false;
            }
        }
        catch (Exception ex) {
            throw ex;
        }
    }
    public bool CreateRockstarRule(int RuleType, string Range) {
        try {

            #region Rules buffer
            INetFwRule2 outUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 inUDP = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            // =============== Out UDP ================ \\

            outUDP.Name = _RockstarGamesRulesName + "OutUDP";
            outUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            outUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            outUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            outUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            outUDP.Protocol = PortProtocol.UDP;
            outUDP.LocalPorts = _RockstarGamesPorts;
            outUDP.RemoteAddresses = Range;
            outUDP.InterfaceTypes = "All";
            outUDP.Enabled = true;
            Console.WriteLine("Rockstar OutUDP created");

            // =============== In  UDP ================ \\

            inUDP.Name = _RockstarGamesRulesName + "InUDP";
            inUDP.Description = "Blocks certain ports from connecting to block anyone from matchmaking in Destiny 2";
            inUDP.Profiles = (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL;
            inUDP.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            inUDP.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            inUDP.Protocol = PortProtocol.UDP;
            inUDP.LocalPorts = _RockstarGamesPorts;
            inUDP.RemoteAddresses = Range;
            inUDP.InterfaceTypes = "All";
            inUDP.Enabled = true;
            Console.WriteLine("Rockstar InUDP created");
            #endregion

            switch (RuleType) {
                case -1: // All
                    firewallPolicy.Rules.Add(outUDP);
                    _RockstarGamesOutUDPRuleCreated = true;
                    _RockstarGamesOutUDPEnabled = true;
                    Console.WriteLine("Rockstar added OutUDP to the firewall");
                    firewallPolicy.Rules.Add(inUDP);
                    _RockstarGamesInUDPRuleCreated = true;
                    _RockstarGamesInUDPEnabled = true;
                    Console.WriteLine("Rockstar added InUDP to the firewall");
                    _RockstarGamesRulesActivated = true;
                    return true;
                case 0: //outUDP
                    firewallPolicy.Rules.Add(outUDP);
                    _RockstarGamesOutUDPRuleCreated = true;
                    _RockstarGamesOutUDPEnabled = true;
                    Console.WriteLine("Rockstar added OutUDP to the firewall");
                    _RockstarGamesRulesActivated = true;
                    return true;
                case 1: //inUDP
                    firewallPolicy.Rules.Add(inUDP);
                    _RockstarGamesInUDPRuleCreated = true;
                    _RockstarGamesInUDPEnabled = true;
                    Console.WriteLine("Rockstar added InUDP to the firewall");
                    _RockstarGamesRulesActivated = true;
                    return true;
                default:
                    return false;
            }
        }
        catch (Exception ex) { throw ex; }
    }

    public bool ToggleDestinyRules(bool Enabled) {
        try {

            if (!_Destiny2OutTCPRuleCreated) {
                CreateDestinyRule(DestinyRuleTypes.OutTCP);
            }
            if (!_Destiny2OutUDPRuleCreated) {
                CreateDestinyRule(DestinyRuleTypes.OutUDP);
            }
            if (!_Destiny2InTCPRuleCreated) {
                CreateDestinyRule(DestinyRuleTypes.InTCP);
            }
            if (!_Destiny2InUDPRuleCreated) {
                CreateDestinyRule(DestinyRuleTypes.InUDP);
            }

            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                if (FoundRule.Name == _Destiny2RulesName + "OutTCP") {
                    FoundRule.Enabled = Enabled;
                    _Destiny2OutTCPEnabled = Enabled;
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "OutUDP") {
                    FoundRule.Enabled = Enabled;
                    _Destiny2OutUDPEnabled = Enabled;
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InTCP") {
                    FoundRule.Enabled = Enabled;
                    _Destiny2InTCPEnabled = Enabled;
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InUDP") {
                    FoundRule.Enabled = Enabled;
                    _Destiny2InUDPEnabled = Enabled;
                    continue;
                }
            }

            _Destiny2RulesAcitvated = Enabled;

            return true;
        }
        catch (Exception ex) { throw ex; }
    }
    public bool ToggleRockstarRules(bool Enabled, string Range) {
        try {
            if (Enabled) {
                CreateRockstarRule(-1, Range);
            }
            else {
                DeleteRockstarRules();
            }

            _RockstarGamesRulesActivated = Enabled;

            //if (!_RockstarGamesOutUDPRuleCreated) {
            //    CreateRockstarRule(RockstarGamesRuleTypes.OutUDP);
            //}
            //if (!_RockstarGamesInUDPRuleCreated) {
            //    CreateRockstarRule(RockstarGamesRuleTypes.InUDP);
            //}

            //Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            //INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            //foreach (INetFwRule FoundRule in fwPolicy.Rules) {
            //    if (FoundRule.Name == _RockstarGamesRulesName + "OutUDP") {
            //        FoundRule.Enabled = Enabled;
            //        continue;
            //    }
            //    else if (FoundRule.Name == _RockstarGamesRulesName + "InUDP") {
            //        FoundRule.Enabled = Enabled;
            //        continue;
            //    }
            //}

            return true;
        }
        catch (Exception ex) { throw ex; }
    }

    public bool RenameDestinyRules(string NewName) {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                if (FoundRule.Name == _Destiny2RulesName + "OutTCP") {
                    FoundRule.Name = NewName + "OutTCP";
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "OutUDP") {
                    FoundRule.Name = NewName + "OutUDP";
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InTCP") {
                    FoundRule.Name = NewName + "InTCP";
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InUDP") {
                    FoundRule.Name = NewName + "InUDP";
                    continue;
                }
            }

            return true;
        }
        catch (Exception ex) { throw ex; }
    }
    public bool RenameRockstarRules(string NewName) {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                if (FoundRule.Name == _RockstarGamesRulesName + "OutUDP") {
                    FoundRule.Name = NewName + "OutUDP";
                    continue;
                }
                else if (FoundRule.Name == _RockstarGamesRulesName + "InUDP") {
                    FoundRule.Name = NewName + "InUDP";
                    continue;
                }
            }

            return true;
        }
        catch (Exception ex) { throw ex; }
    }

    public bool UpdateDestinyRules() {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                if (FoundRule.Name == _Destiny2RulesName + "OutTCP") {
                    if (Configuration.Default.DestinyBlockLocalPorts) {
                        FoundRule.LocalPorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.LocalPorts = string.Empty;
                    }
                    if (Configuration.Default.DestinyBlockRemotePorts) {
                        FoundRule.RemotePorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.RemotePorts = string.Empty;
                    }
                    if (Configuration.Default.DestinySpecifyApplication) {
                        FoundRule.ApplicationName = Configuration.Default.DestinyExecutable;
                    }
                    else {
                        FoundRule.ApplicationName = null;
                    }
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "OutUDP") {
                    if (Configuration.Default.DestinyBlockLocalPorts) {
                        FoundRule.LocalPorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.LocalPorts = string.Empty;
                    }
                    if (Configuration.Default.DestinyBlockRemotePorts) {
                        FoundRule.RemotePorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.RemotePorts = string.Empty;
                    }
                    if (Configuration.Default.DestinySpecifyApplication) {
                        FoundRule.ApplicationName = Configuration.Default.DestinyExecutable;
                    }
                    else {
                        FoundRule.ApplicationName = null;
                    }
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InTCP") {
                    if (Configuration.Default.DestinyBlockLocalPorts) {
                        FoundRule.LocalPorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.LocalPorts = string.Empty;
                    }
                    if (Configuration.Default.DestinyBlockRemotePorts) {
                        FoundRule.RemotePorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.RemotePorts = string.Empty;
                    }
                    if (Configuration.Default.DestinySpecifyApplication) {
                        FoundRule.ApplicationName = Configuration.Default.DestinyExecutable;
                    }
                    else {
                        FoundRule.ApplicationName = null;
                    }
                    continue;
                }
                else if (FoundRule.Name == _Destiny2RulesName + "InUDP") {
                    if (Configuration.Default.DestinyBlockLocalPorts) {
                        FoundRule.LocalPorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.LocalPorts = string.Empty;
                    }
                    if (Configuration.Default.DestinyBlockRemotePorts) {
                        FoundRule.RemotePorts = Configuration.Default.DestinyPorts;
                    }
                    else {
                        FoundRule.RemotePorts = string.Empty;
                    }
                    if (Configuration.Default.DestinySpecifyApplication) {
                        FoundRule.ApplicationName = Configuration.Default.DestinyExecutable;
                    }
                    else {
                        FoundRule.ApplicationName = null;
                    }
                    continue;
                }
            }

            return true;
        }
        catch (Exception ex) { throw ex; }
    }
    public bool UpdateRockstarRules() {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            foreach (INetFwRule FoundRule in fwPolicy.Rules) {
                if (FoundRule.Name == _RockstarGamesRulesName + "OutUDP") {
                    FoundRule.LocalPorts = Configuration.Default.RockstarPorts;
                    continue;
                }
                else if (FoundRule.Name == _RockstarGamesRulesName + "InUDP") {
                    FoundRule.LocalPorts = Configuration.Default.RockstarPorts;
                    continue;
                }
            }
            return true;
        }
        catch (Exception ex) { throw ex; }
    }

    public bool DeleteDestinyRules() {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            fwPolicy.Rules.Remove(_Destiny2RulesName + "OutTCP");
            _Destiny2OutTCPRuleCreated = false;
            _Destiny2OutTCPEnabled = false;
            Console.WriteLine("Destiny 2 OutTCP has been removed");
            fwPolicy.Rules.Remove(_Destiny2RulesName + "OutUDP");
            _Destiny2OutUDPRuleCreated = false;
            _Destiny2OutUDPEnabled = false;
            Console.WriteLine("Destiny 2 OutUDP has been removed");
            fwPolicy.Rules.Remove(_Destiny2RulesName + "InTCP");
            _Destiny2InTCPRuleCreated = false;
            _Destiny2InTCPEnabled = false;
            Console.WriteLine("Destiny 2 InTCP has been removed");
            fwPolicy.Rules.Remove(_Destiny2RulesName + "InUDP");
            _Destiny2InUDPRuleCreated = false;
            _Destiny2InUDPEnabled = false;
            Console.WriteLine("Destiny 2 InUDP has been removed");

            _Destiny2RulesAcitvated = false;
            return true;
        }
        catch (Exception ex) { throw ex; }
    }
    public bool DeleteRockstarRules() {
        try {
            Type firewallType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy = (INetFwPolicy2)Activator.CreateInstance(firewallType);

            fwPolicy.Rules.Remove(_RockstarGamesRulesName + "OutUDP");
            _RockstarGamesOutUDPRuleCreated = false;
            _RockstarGamesOutUDPEnabled = false;
            Console.WriteLine("Rockstar OutUDP has been removed");
            fwPolicy.Rules.Remove(_RockstarGamesRulesName + "InUDP");
            _RockstarGamesInUDPRuleCreated = false;
            _RockstarGamesInUDPEnabled = false;
            Console.WriteLine("Rockstar InUDP has been removed");

            _RockstarGamesRulesActivated = false;
            return true;
        }
        catch (Exception ex) { throw ex; }
    }
}

class DestinyRuleTypes {
    public static int AllRules { get { return -1; } }
    public static int OutTCP { get { return 0; } }
    public static int OutUDP { get { return 1; } }
    public static int InTCP { get { return 2; } }
    public static int InUDP { get { return 3; } }
}
class RockstarGamesRuleTypes {
    public static int AllRules { get { return -1; } }
    public static int OutUDP { get { return 0; } }
    public static int InUDP { get { return 1; } }
}

public static class PortProtocol {
    public static int TCP { get { return 6; } }
    public static int UDP { get { return 17; } }
}