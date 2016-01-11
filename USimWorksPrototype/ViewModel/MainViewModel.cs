using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
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
                    new Device(1),
                    new Device(2){IsActive =true},
                    new Device(3){IsActive =true},
                    new Device(4){IsActive =true},
                    new Device(5),
                    new Device(6){IsActive =true},
                    new Device(7),
                    new Device(8){IsActive =true}
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
                    new Model(1){ModelType = ModelType.MatLab},
                    new Model(2){ModelType = ModelType.Rhapsody},
                    new Model(3){ModelType = ModelType.SkyEye},
                    new Model(4){ModelStatus = ModelStatus.Pause},
                    new Model(5){ModelStatus = ModelStatus.Ready},
                    new Model(6){ModelStatus = ModelStatus.Stopped},
                    new Model(7){ModelStatus = ModelStatus.Running},
                    new Model(8){ModelType = ModelType.Updm}
                });
            }
        }

        private ObservableCollection<Project> _projects;

        public ObservableCollection<Project> Projects
        {
            get
            {
                return _projects ?? (_projects = new ObservableCollection<Project>
                {
                    new Project("工程1"){ModelCollection = Models},
                    new Project("工程2"),
                    new Project("工程3"),
                    new Project("工程4"),
                    new Project("工程5"),
                    new Project("工程6"),
                    new Project("工程7")
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

    public class Project
    {
        public string ProjectName { get; set; }
        private ObservableCollection<Model> _modelCollection;

        public Project(string projectName)
        {
            ProjectName = projectName;
        }

        public ObservableCollection<Model> ModelCollection
        {
            get
            {
                return _modelCollection??(_modelCollection=new ObservableCollection<Model>
                {
                    new Model(1),
                    new Model(2),
                    new Model(3),
                    new Model(4),
                    new Model(5),
                    new Model(6),
                });
            }
            set { _modelCollection = value; }
        } 
    }

    public class Device
    {
        public Device(int num)
        {
            DeviceName = "设备"+num;
            _deviceNum = num;
        }
        public string DeviceName { get; set; }
        public IPAddress IpAddress { get; set; }
        public bool IsActive { get; set; }
        private int _deviceNum;

        private ObservableCollection<Model> _modelCollection;

        public ObservableCollection<Model> ModelCollection
        {
            get
            {
                return _modelCollection ?? (_modelCollection = new ObservableCollection<Model>
                {
                    new Model(_deviceNum,1){ModelType = ModelType.MatLab},
                    new Model(_deviceNum,2){ModelType = ModelType.Rhapsody},
                    new Model(_deviceNum,3){ModelType = ModelType.SkyEye},
                    new Model(_deviceNum,4){ModelStatus = ModelStatus.Pause},
                    new Model(_deviceNum,5){ModelStatus = ModelStatus.Ready},
                    new Model(_deviceNum,6){ModelStatus = ModelStatus.Stopped},
                    new Model(_deviceNum,7){ModelStatus = ModelStatus.Running},
                    new Model(_deviceNum,8){ModelType = ModelType.Updm}
                });
            }
        }
    }

    public class Model
    {
        private List<Port> _portList;

        public Model(params int[] num)
        {
            ModelName = "模型";
            if (num.Count() >= 1)
            {
                foreach (int n in num)
                {
                    ModelName += n + ".";
                }
                ModelName = ModelName.Remove(ModelName.Count() - 1);
            }
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
        SkyEye,
        Other
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