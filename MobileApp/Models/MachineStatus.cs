using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public enum MachineState
    {
        Running,
        Stopped,
        Idle
    }

    public class MachineStatus
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public MachineState State { get; set; } = MachineState.Idle;

        // Efficiency as a percentage (0-100)
        public double EfficiencyPercent { get; set; }

        // Units produced in the current shift/session
        public int ProductionCount { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // How long the machine has been in its current state (used to trigger downtime alerts)
        public DateTime StateSince { get; set; } = DateTime.Now;

        public string StatusColor => State switch
        {
            MachineState.Running => "#22c55e", // green
            MachineState.Stopped => "#ef4444", // red
            MachineState.Idle => "#f59e0b",    // amber
            _ => "#94a3b8"
        };

        public string StatusLabel => State switch
        {
            MachineState.Running => "Running",
            MachineState.Stopped => "Stopped",
            MachineState.Idle => "Idle",
            _ => "Unknown"
        };
    }

    public class MachineAlert
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime RaisedAt { get; set; } = DateTime.Now;
        public bool Acknowledged { get; set; }
    }
}
