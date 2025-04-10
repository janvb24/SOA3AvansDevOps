﻿using AvansDevops.Notifications;
using AvansDevops.ProjectManagementSystem.backlog;

namespace AvansDevops.ProjectManagementSystem.backlog.state
{
    public class TestedBacklogItemState : IBacklogItemState
    {
        private BacklogItem _backlogItem;
        private readonly INotificationService _notificationService;
        private User? _tester;

        public TestedBacklogItemState(BacklogItem backlogItem, INotificationService notificationService, User? tester) {
            _backlogItem = backlogItem;
            _notificationService = notificationService;
            _tester = tester;
        }

        public void UpdateTester(User? tester) {
            _tester = tester;
        }

        public void Approve()
        {
            Console.WriteLine("Backlog item approved");
            _backlogItem.currentState = _backlogItem.doneState;
        }

        public void Complete()
        {
            Console.WriteLine("Backlog item in tested cannot be completed");
        }

        public void Deny()
        {
            Console.WriteLine("Backlog item in tested denied, switched to Ready for testing");
            _backlogItem.currentState = _backlogItem.readyForTestingState;
            _notificationService.Send(_tester != null ? [_tester] : [], "Backlog item is denied, switched back to testing");
        }

        public void Start()
        {
            Console.WriteLine("Backlog item in tested cannot be started");
        }
    }
}
