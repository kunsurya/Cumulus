using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cumulus
{

    [XmlRoot(ElementName = "Link", Namespace = "http://www.vmware.com/vcloud/v1.5")]
    public class Link
    {
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
    }

    [XmlRoot(ElementName = "VAppRecord", Namespace = "http://www.vmware.com/vcloud/v1.5")]
    public class VAppRecord
    {
        [XmlAttribute(AttributeName = "vdcName")]
        public string VdcName { get; set; }
        [XmlAttribute(AttributeName = "vdc")]
        public string Vdc { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "ownerName")]
        public string OwnerName { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "isPublic")]
        public string IsPublic { get; set; }
        [XmlAttribute(AttributeName = "isInMaintenanceMode")]
        public string IsInMaintenanceMode { get; set; }
        [XmlAttribute(AttributeName = "isEnabled")]
        public string IsEnabled { get; set; }
        [XmlAttribute(AttributeName = "isDeployed")]
        public string IsDeployed { get; set; }
        [XmlAttribute(AttributeName = "isBusy")]
        public string IsBusy { get; set; }
        [XmlAttribute(AttributeName = "creationDate")]
        public string CreationDate { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
        [XmlAttribute(AttributeName = "cpuAllocationMhz")]
        public string CpuAllocationMhz { get; set; }
        [XmlAttribute(AttributeName = "cpuAllocationInMhz")]
        public string CpuAllocationInMhz { get; set; }
        [XmlAttribute(AttributeName = "task")]
        public string Task { get; set; }
        [XmlAttribute(AttributeName = "isAutoDeleteNotified")]
        public string IsAutoDeleteNotified { get; set; }
        [XmlAttribute(AttributeName = "numberOfVMs")]
        public string NumberOfVMs { get; set; }
        [XmlAttribute(AttributeName = "autoUndeployDate")]
        public string AutoUndeployDate { get; set; }
        [XmlAttribute(AttributeName = "isAutoUndeployNotified")]
        public string IsAutoUndeployNotified { get; set; }
        [XmlAttribute(AttributeName = "taskStatusName")]
        public string TaskStatusName { get; set; }
        [XmlAttribute(AttributeName = "isVdcEnabled")]
        public string IsVdcEnabled { get; set; }
        [XmlAttribute(AttributeName = "honorBootOrder")]
        public string HonorBootOrder { get; set; }
        [XmlAttribute(AttributeName = "pvdcHighestSupportedHardwareVersion")]
        public string PvdcHighestSupportedHardwareVersion { get; set; }
        [XmlAttribute(AttributeName = "lowestHardwareVersionInVApp")]
        public string LowestHardwareVersionInVApp { get; set; }
        [XmlAttribute(AttributeName = "taskStatus")]
        public string TaskStatus { get; set; }
        [XmlAttribute(AttributeName = "storageKB")]
        public string StorageKB { get; set; }
        [XmlAttribute(AttributeName = "taskDetails")]
        public string TaskDetails { get; set; }
        [XmlAttribute(AttributeName = "numberOfCpus")]
        public string NumberOfCpus { get; set; }
        [XmlAttribute(AttributeName = "memoryAllocationMB")]
        public string MemoryAllocationMB { get; set; }
    }

    [XmlRoot(ElementName = "QueryResultRecords", Namespace = "http://www.vmware.com/vcloud/v1.5")]
    public class QueryResultRecords
    {
        [XmlElement(ElementName = "Link", Namespace = "http://www.vmware.com/vcloud/v1.5")]
        public List<Link> Link { get; set; }
        [XmlElement(ElementName = "VAppRecord", Namespace = "http://www.vmware.com/vcloud/v1.5")]
        public List<VAppRecord> VAppRecord { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "pageSize")]
        public string PageSize { get; set; }
        [XmlAttribute(AttributeName = "page")]
        public string Page { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
    }
}
