using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class MachineMonitorService : IDisposable
    {
        private readonly System.Timers.Timer _pollTimer;
        private readonly Random _rng = new();

        public List<MachineStatus> Machines { get; private set; } = new();
        public List<MachineAlert> Alerts { get; private set; } = new();

        // Fired whenever machine data changes, so the UI can refresh
        public event Action? OnDataUpdated;

        // How long a machine can sit "Stopped" before we raise a downtime alert
        private readonly TimeSpan _downtimeThreshold = TimeSpan.FromSeconds(15);

        public MachineMonitorService()
        {
            SeedMachines();

            // NOTE: this timer simulates live data for the demo.
            // In production, replace the tick logic with a SignalR client
            // (Microsoft.AspNetCore.SignalR.Client works fine in MAUI) that
            // listens for server-pushed updates instead of polling locally.
            _pollTimer = new System.Timers.Timer(2000);
            _pollTimer.Elapsed += (_, _) => SimulateTick();
            _pollTimer.AutoReset = true;
        }

        public void Start() => _pollTimer.Start();
        public void Stop() => _pollTimer.Stop();

        private void SeedMachines()
        {
            Machines = new List<MachineStatus>
            {
                new() { MachineId = 1, MachineName = "Loom 01", State = MachineState.Running, EfficiencyPercent = 92, ProductionCount = 480 },
                new() { MachineId = 2, MachineName = "Loom 02", State = MachineState.Running, EfficiencyPercent = 87, ProductionCount = 455 },
                new() { MachineId = 3, MachineName = "Loom 03", State = MachineState.Idle,    EfficiencyPercent = 0,  ProductionCount = 210 },
                new() { MachineId = 4, MachineName = "Loom 04", State = MachineState.Stopped, EfficiencyPercent = 0,  ProductionCount = 300 },
            };
        }

        private void SimulateTick()
        {
            foreach (var m in Machines)
            {
                if (m.State == MachineState.Running)
                {
                    m.ProductionCount += _rng.Next(1, 5);
                    m.EfficiencyPercent = Math.Clamp(m.EfficiencyPercent + _rng.Next(-2, 3), 60, 100);

                    // small random chance a running machine stops
                    if (_rng.Next(0, 20) == 0)
                        ChangeState(m, MachineState.Stopped);
                }
                else if (m.State == MachineState.Idle)
                {
                    if (_rng.Next(0, 8) == 0)
                        ChangeState(m, MachineState.Running);
                }

                m.LastUpdated = DateTime.Now;

                if (m.State == MachineState.Stopped && DateTime.Now - m.StateSince > _downtimeThreshold)
                {
                    RaiseDowntimeAlert(m);
                    m.StateSince = DateTime.Now; // avoid repeated alerts every tick
                }
            }

            OnDataUpdated?.Invoke();
        }

        private void ChangeState(MachineStatus m, MachineState newState)
        {
            m.State = newState;
            m.StateSince = DateTime.Now;
            if (newState == MachineState.Stopped)
                m.EfficiencyPercent = 0;
        }

        private void RaiseDowntimeAlert(MachineStatus m)
        {
            Alerts.Insert(0, new MachineAlert
            {
                MachineId = m.MachineId,
                MachineName = m.MachineName,
                Message = $"{m.MachineName} has been stopped for over {_downtimeThreshold.TotalSeconds:0}s",
            });

            // keep the alert list from growing forever
            if (Alerts.Count > 20)
                Alerts.RemoveAt(Alerts.Count - 1);
        }

        public void AcknowledgeAlert(MachineAlert alert)
        {
            alert.Acknowledged = true;
            OnDataUpdated?.Invoke();
        }

        public void Dispose()
        {
            _pollTimer?.Stop();
            _pollTimer?.Dispose();
        }
    }
}
