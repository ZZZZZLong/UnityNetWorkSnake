// Copyright 2019 Google LLC
// All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Modified from https://github.com/googleforgames/agones unity sdk

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Unity.Cn.Multiverse.Model
{
    /// <summary>
    /// GameServerSpec
    /// </summary>
    public class GameServerSpec : IEquatable<GameServerSpec>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameServerSpec" /> class.
        /// </summary>
        public GameServerSpec(IReadOnlyDictionary<string, object> data)
        {
            this.Health = new SpecHealth((Dictionary<string, object>) data["health"]);
            if (data.TryGetValue("env", out var envs))
            {
                this.Env = new Dictionary<string, string>();
                var values = (Dictionary<string, object>) envs;
                foreach (var item in values)
                {
                    this.Env.Add(item.Key, item.Value.ToString());
                }
            }
        }

        public SpecHealth Health { get; set; }
        public Dictionary<string, string> Env { get; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GameServerSpec {\n");
            sb.Append("  Health: ").Append(Health).Append("\n");
            sb.Append("  Env: ").Append(Env).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as GameServerSpec);
        }

        /// <summary>
        /// Returns true if GameServerSpec instances are equal
        /// </summary>
        /// <param name="input">Instance of GameServerSpec to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GameServerSpec input)
        {
            if (input == null)
                return false;

            return
            (
                this.Health == input.Health ||
                (this.Health != null &&
                 this.Health.Equals(input.Health))
            ) &&
            (
                this.Env == input.Env ||
                this.Env != null &&
                this.Env.SequenceEqual(input.Env)
            );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Health != null)
                    hashCode = hashCode * 59 + this.Health.GetHashCode();
                if (this.Env != null)
                    hashCode = hashCode * 59 + this.Env.GetHashCode();
                return hashCode;
            }
        }
    }
}
