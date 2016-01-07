using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using GalaSoft.MvvmLight;
using USimWorksPrototype.Model;

namespace USimWorksPrototype.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Property> _properties;

        public ObservableCollection<Property> Properties
        {
            get
            {
                return _properties ?? (_properties = new ObservableCollection<Property>
            {
                new Property("模型名称"),
                new Property("模型描述"),
                new Property("输入端口数量"),
                new Property("输出端口数量"),
                new Property("开始时间"),
                new Property("结束时间"),
                new Property("仿真步长")
            }); }
        }

        private ObservableCollection<Device> _devices;

        public ObservableCollection<Device> Devices
        {
            get
            {
                return _devices??(_devices=new ObservableCollection<Device>
                {
                    new Device("设备1"),
                    new Device("设备2"){DeviceType = DeviceType.Win8},
                    new Device("设备3"){DeviceType = DeviceType.Win10},
                    new Device("设备4"){DeviceType = DeviceType.WinXp},
                    new Device("设备5"){DeviceType = DeviceType.Other},
                    new Device("设备6"),
                    new Device("设备7"),
                    new Device("设备8")
                });
            }
        } 

        private ObservableCollection<Model> _models; 
        public ObservableCollection<Model> Models
        {
            get
            {
                return _models??(_models=new ObservableCollection<Model>
                {
                    new Model("模型1"){ModelType = ModelType.MatLab},
                    new Model("模型2"){ModelType = ModelType.Rhapsody},
                    new Model("模型3"){ModelType = ModelType.SkyEye},
                    new Model("模型4"){ModelStatus = ModelStatus.Pause,ModelType = ModelType.Stk},
                    new Model("模型5"){ModelStatus = ModelStatus.Ready},
                    new Model("模型6"){ModelStatus = ModelStatus.Stopped},
                    new Model("模型7"){ModelStatus = ModelStatus.Running},
                    new Model("模型8"){ModelType = ModelType.Updm}
                });
            }
        }
    }

    public class Property
    {
        public Property(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string Value { get; set; }
    }

    public class Device
    {
        public Device(string deviceName)
        {
            DeviceName = deviceName;
        }

        public DeviceType DeviceType { get; set; }
        public string DeviceName { get; set; }
        public IPAddress IpAddress { get; set; }
    }

    public enum DeviceType
    {
        Win7,
        WinXp,
        Win8,
        Win10,
        Other
    }

    public class Model
    {
        private List<Port> _portList;

        public Model(string modelName)
        {
            ModelName = modelName;
        }

        public ModelType ModelType { get; set; }
        public ModelStatus ModelStatus { get; set; }
        public string ModelName { get; set; }

        public List<Port> PortList
        {
            get
            {
                return _portList ?? (_portList = new List<Port>
                {
                    new Port("in1", PortType.Input),
                    new Port("out1", PortType.OutPut)
                });
            }
        }
    }

    public enum ModelStatus
    {
        UnLink,
        Ready,
        Stopped,
        Running,
        Pause
    }

    public enum ModelType
    {
        C,
        MatLab,
        Updm,
        Rhapsody,
        Stk,
        SkyEye
    }

    public class Port
    {
        public Port(string portName, PortType portType)
        {
            PortName = portName;
            PortType = portType;
        }

        public string PortName { get; set; }
        public PortType PortType { get; set; }
    }

    public enum PortType
    {
        Input,
        OutPut
    }
}