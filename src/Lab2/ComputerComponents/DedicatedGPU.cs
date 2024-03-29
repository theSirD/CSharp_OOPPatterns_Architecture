using Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;

public class DedicatedGPU : BaseRepoItem
{
    public DedicatedGPU(string name, int w, int h, int vram, int pcieVersion, double freq, int consump)
        : base(name)
    {
        WidthInSm = w;
        HeightInSm = h;
        VRAMAmount = vram;
        PcieVersion = pcieVersion;
        FrequencyInGhz = freq;
        PowerConsumptionInWt = consump;
    }

    public int WidthInSm { get; set; }
    public int HeightInSm { get; init; }
    public int VRAMAmount { get; init; }
    public int PcieVersion { get; init; }
    public double FrequencyInGhz { get; init; }
    public int PowerConsumptionInWt { get; init; }

    public void CanBePlaced(ComputerConfiguration computer)
    {
        if (computer?.MotherBoard is null)
            throw new BuildLacksRequiredComponentsException("Install mother board first");

        if (computer.MotherBoard.PcieVersion < PcieVersion)
            throw new ComponentIsNotSupportedException("Mother board's PCIE is too old for this GPU");

        if (computer.MotherBoard.PciLinesAmount < computer.MotherBoard.CurPciLinesAmount + 1)
            throw new NotEnoughPortsException("Mother board does not have enough PCIE lines");
    }

    public DedicatedGPU CloneWithNewFrequency(string newName, double freq)
    {
        return new DedicatedGPU(newName, WidthInSm, HeightInSm, VRAMAmount, PcieVersion, freq, PowerConsumptionInWt);
    }

    public override BaseRepoItem Clone()
    {
        return new DedicatedGPU(Name, WidthInSm, HeightInSm, VRAMAmount, PcieVersion, FrequencyInGhz, PowerConsumptionInWt);
    }
}